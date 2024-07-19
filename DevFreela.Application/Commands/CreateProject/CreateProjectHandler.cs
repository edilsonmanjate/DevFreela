using DevFreela.Core.Entities;
using DevFreela.Infrastruture.Persistence;

using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public CreateProjectHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdCliente, request.IdFreelancer, request.TotalCost);
            await _devFreelaDbContext.Projects.AddAsync(project);
            await _devFreelaDbContext.SaveChangesAsync();
            return  project.Id;
        }
    }
}
