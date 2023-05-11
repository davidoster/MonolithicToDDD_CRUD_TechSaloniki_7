using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.RepoInterfaces;

namespace Monolithic_MVC_Demo.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public Skill GetSkillById(int id)
        {
            return _skillRepository.GetSkillById(id);
        }

        public List<Skill> GetAllSkills()
        {
            return _skillRepository.GetAllSkills();
        }

        public void AddSkill(Skill skill)
        {
            _skillRepository.AddSkill(skill);
        }

        public void UpdateSkill(Skill skill)
        {
            _skillRepository.UpdateSkill(skill);
        }

        public void DeleteSkill(int id)
        {
            _skillRepository.DeleteSkill(id);
        }
    }
}

