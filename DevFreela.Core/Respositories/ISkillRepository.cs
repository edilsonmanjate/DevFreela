using DevFreela.Core.DTOs;

namespace DevFreela.Core.Respositories;

public interface ISkillRepository
{
    Task<List<SkillDTO>> GetAllAsync();

}
