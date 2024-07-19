using Dapper;

using DevFreela.Application.ViewModels;
using DevFreela.Infrastruture.Persistence;

using MediatR;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;
        public string _connectionString { get; set; }

        public GetAllSkillsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCsHome");
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            var script = "SELECT Id, Description FROM Skills";
            var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);
            return skills.ToList();
        }
    }
}
