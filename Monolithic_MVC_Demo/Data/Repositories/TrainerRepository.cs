using Microsoft.EntityFrameworkCore;
using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.RepoInterfaces;

namespace Monolithic_MVC_Demo.Data.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        public readonly WebAppDbContext _dbContext;

        public TrainerRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  List<Skill> GetAllSkills()
        {
            return _dbContext.Skills.ToList();
        }

        public List<Skill> GetSkillsByIds(int[] ids)
        {
            return _dbContext.Skills.Where(s => ids.Contains(s.Id)).ToList();
        }

        public Trainer GetTrainerById(int id)
        {
            return _dbContext.Trainers.Include(t => t.Skills).FirstOrDefault(t => t.Id == id);
        }


        public List<Trainer> GetAllTrainers()
        {
            return _dbContext.Trainers
                .Include(t => t.Skills)
                .ToList();
        }

        public void AddTrainer(Trainer trainer)
        {

            _dbContext.Trainers.Add(trainer);
            _dbContext.SaveChanges();
        }

        public void UpdateTrainer(Trainer trainer)
        {
            var existingTrainer = _dbContext.Trainers
                .Include(t => t.Skills)
                .FirstOrDefault(t => t.Id == trainer.Id);

            if (existingTrainer != null)
            {
                
                existingTrainer.FirstName = trainer.FirstName;
                existingTrainer.LastName = trainer.LastName;
                existingTrainer.Email = trainer.Email;
                existingTrainer.PhoneNumber = trainer.PhoneNumber;

                
                existingTrainer.Skills.Clear();
                foreach (var skill in trainer.Skills)
                {
                    var existingSkill = _dbContext.Skills.FirstOrDefault(s => s.Id == skill.Id);
                    if (existingSkill != null)
                    {
                        existingTrainer.Skills.Add(existingSkill);
                    }
                }

                _dbContext.SaveChanges();
            }
        }

        public void DeleteTrainer(int id)
        {
            var trainerToDelete = GetTrainerById(id);

            if (trainerToDelete != null)
            {
                _dbContext.Trainers.Remove(trainerToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}
