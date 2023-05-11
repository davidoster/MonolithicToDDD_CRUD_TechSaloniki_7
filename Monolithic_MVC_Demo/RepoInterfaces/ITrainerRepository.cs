using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.Services;

namespace Monolithic_MVC_Demo.RepoInterfaces
{
    public interface ITrainerRepository
    {
        Trainer GetTrainerById(int id);
        List<Trainer> GetAllTrainers();
        void AddTrainer(Trainer trainer);
        void UpdateTrainer(Trainer trainer);
        void DeleteTrainer(int id);
        List<Skill> GetAllSkills();
        List<Skill> GetSkillsByIds(int[] ids);
    }

}
