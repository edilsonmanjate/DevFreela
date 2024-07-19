using DevFreela.Core.DTOs;
using DevFreela.Core.Respositories;

using MediatR;

using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        public string _connectionString { get; set; }
        public readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(IConfiguration configuration, ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllAsync();
        }
    }
}
