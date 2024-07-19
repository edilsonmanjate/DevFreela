using DevFreela.Infrastruture.Persistence;

using MediatR;

namespace DevFreela.Application.Commands.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public DeleteProjectCommandHandler(DevFreelaDbContext devFreelaDbContext )
        {
            _devFreelaDbContext = devFreelaDbContext;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Cancel();
            await _devFreelaDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
