using Dapper;

using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastruture.Persistence;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext devFreelaDbContext, IConfiguration configuration)
        {
            _devFreelaDbContext = devFreelaDbContext;
            _connectionString = configuration.GetConnectionString("DeveFreelaCs");
        }
        public List<SkillViewModel> GetAll()
        {
            //var skills = _devFreelaDbContext.Skills;
            //var skillsViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id,s.Description,s.CreatedAt))
            //    .ToList();

            //return skillsViewModel;

            using var sqlConnection = new SqlConnection(_connectionString);
            var script = "SELECT Id, Description FROM Skills";
            var skills = sqlConnection.Query<SkillViewModel>(script);
            return skills.ToList();
        }
    }
}
