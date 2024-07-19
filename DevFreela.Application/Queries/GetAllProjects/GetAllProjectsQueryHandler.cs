using DevFreela.Application.ViewModels;
using DevFreela.Infrastruture.Persistence;

using MediatR;

using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public string _connectionString { get; set; }

        public GetAllProjectsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCsHome");
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _devFreelaDbContext.Projects;
            var projectsViewModel =  projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }
    }
}
