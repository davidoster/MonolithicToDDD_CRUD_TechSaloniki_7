using Monolithic_MVC_Demo.Models;

namespace Monolithic_MVC_Demo.Services
{
    public interface ISkillService
    {
        Skill GetSkillById(int id);
        List<Skill> GetAllSkills();
        void AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
