using DevFreela.Application.Commands.CreateProject;
using DevFreela.Infrastruture.Persistence;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProjectCommand
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public UpdateProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

    
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Update(request.Title, request.Description, request.TotalCost);
            await _devFreelaDbContext.SaveChangesAsync();

            return Unit.Value;
            
        }
    }
}
