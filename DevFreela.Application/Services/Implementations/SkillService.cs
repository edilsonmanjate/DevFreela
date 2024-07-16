using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastruture.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        public readonly DevFreelaDbContext _devFreelaDbContext;

        public SkillService(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext = devFreelaDbContext;
        }
        public List<SkillViewModel> GetAll()
        {
            var skills = _devFreelaDbContext.Skills;
            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Id,s.Description,s.CreatedAt))
                .ToList();

            return skillsViewModel;
        }
    }
}
