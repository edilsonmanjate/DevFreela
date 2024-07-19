using DevFreela.Core.Entities;
using DevFreela.Infrastruture.Persistence;

using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand,Unit>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public CreateCommentCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdUser, request.IdUser);
            await _devFreelaDbContext.ProjectComments.AddAsync(comment);
            await _devFreelaDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
