using Monolithic_MVC_Demo.Data;
using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.RepoInterfaces;

namespace Monolithic_MVC_Demo.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly ISkillRepository _skillRepository;

        
        public TrainerService(ITrainerRepository trainerRepository, ISkillRepository skillRepository)
        {
            _trainerRepository = trainerRepository;
            _skillRepository = skillRepository;
        }

        public Trainer GetTrainerById(int id)
        {
            return _trainerRepository.GetTrainerById(id);
        }

        public List<Trainer> GetAllTrainers()
        {
            return _trainerRepository.GetAllTrainers();
        }

        public void AddTrainer(Trainer trainer, int[] skillIds)
        {
            if (trainer == null)
            {
                throw new ArgumentNullException(nameof(trainer), "Trainer cannot be null.");
            }

            if (skillIds == null)
            {
                throw new ArgumentNullException(nameof(skillIds), "SkillIds cannot be null.");
            }

            List<Skill> skills = new List<Skill>();
            foreach (int skillid in skillIds)
            {
                Skill skill = _skillRepository.GetSkillById(skillid);
                if (skill == null)
                {
                    throw new ArgumentException($"Invalid skill id: {skillid}.", nameof(skillIds));
                }
                skills.Add(skill);
            }

            trainer.Skills = skills;
            _trainerRepository.AddTrainer(trainer);
        }


        public void UpdateTrainer(Trainer trainer, int[] skills)
        {
            
            List<Skill> updatedSkills = new List<Skill>();

            foreach(int skill in skills) 
            {
                var test = _skillRepository.GetSkillById(skill);
                updatedSkills.Add(test);
            }

            trainer.Skills = updatedSkills;
            _trainerRepository.UpdateTrainer(trainer);

        }

        public void DeleteTrainer(int id)
        {
            _trainerRepository.DeleteTrainer(id);
        }

        public List<Skill> GetAllSkills()
        {
            return _trainerRepository.GetAllSkills();
        }

        public List<Skill> GetSkillsByIds(int[] skillIds)
        {
           return _trainerRepository.GetSkillsByIds(skillIds);
        }
    }


}
