using Monolithic_MVC_Demo.Models;

namespace Monolithic_MVC_Demo.Services
{
    public interface ITrainerService
    {
        Trainer GetTrainerById(int id);
        List<Trainer> GetAllTrainers();
        void AddTrainer(Trainer trainer, int[] skillIds);
        List<Skill> GetAllSkills();

        void UpdateTrainer(Trainer trainer, int[] skills);
        void DeleteTrainer(int id);
        List<Skill> GetSkillsByIds(int[] skillIds);


    }

}
