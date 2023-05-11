using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkills();
        Task<List<Skill>> GetAllSkillsWithTrainers();
        Task<Skill> GetSkillByIdWithTrainers(int id);
        public Task<Skill> GetSkillById(int id);
        public Task<bool> Create(Skill skill);
        public Task<bool> Update(Skill skill);
        public Task<bool> Delete(int skillId);
    }
}
