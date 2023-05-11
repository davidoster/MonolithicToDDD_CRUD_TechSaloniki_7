using Models;

namespace RepoInterfaces
{
    public interface ISkillsRepository
    {
        Task<List<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int id);
        Task<List<Skill>> GetAllSkillsLoaded();
        Task<Skill> GetSkillByIdLoaded(int id);
        Task<bool> AddSkill(Skill skill);
        Task<bool> RemoveSkill(int id);
        Task<List<Skill>> GetSkillsByTrainerId(int id);
    }
}
