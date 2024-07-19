using Dapper;

using DevFreela.Core.DTOs;
using DevFreela.Core.Respositories;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastruture.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public string _connectionString { get; set; }

        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCsHome");
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString); 
            sqlConnection.Open();
            var script = "SELECT Id, Description FROM Skills";
            var skills = await sqlConnection.QueryAsync<SkillDTO>(script);
            return skills.ToList();
        }
    }
}
