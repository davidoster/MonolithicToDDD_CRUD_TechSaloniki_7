using Application.MyUnitOfWork;
using Application.ServiceInterface;
using CRUDDbContext;
using Microsoft.EntityFrameworkCore;
using Models;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrainerService : ITrainerService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;         
        }
        

        public async Task<List<Trainer>> GetAllTrainers()
        {
            return await _unitOfWork.Trainers.GetAllTrainers();
        }

        public async Task<Trainer> GetTrainerById(int id)
        {
            return await _unitOfWork.Trainers.GetTrainerById(id);
        }

        public async Task<bool> Create(Trainer trainer)
        {
            List<Skill> skills = new List<Skill>();
            if (trainer.Skills != null)
            {
                foreach (var skill in trainer.Skills)
                {
                    skills.Add(await _unitOfWork.Skills.GetSkillById(skill.Id));
                } 
                trainer.Skills = skills;          
            }
            var response = await _unitOfWork.Trainers.AddTrainer(trainer);
            _unitOfWork.Save();
            return response;
        }
        
        public async Task<bool> Update(Trainer trainer)
        {
            try
            {
                var existingTrainer = await _unitOfWork.Trainers.GetTrainerByIdLoaded(trainer.Id); 
                List<Skill> newSkills = new();
                if (trainer.Skills != null)
                {
                    foreach (Skill skill in trainer.Skills)
                    {
                        newSkills.Add(await _unitOfWork.Skills.GetSkillByIdLoaded(skill.Id));
                    } 
                }    
                existingTrainer.Skills?.Clear();
                existingTrainer.Skills = newSkills;
                existingTrainer.FirstName = trainer.FirstName;
                existingTrainer.LastName = trainer.LastName;
                existingTrainer.PhoneNumber = trainer.PhoneNumber;
                existingTrainer.Email = trainer.Email;
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
    public async Task<bool> Delete(int trainerId)
        {
             var response = await _unitOfWork.Trainers.RemoveTrainer(trainerId);
             _unitOfWork.Save();
             return response;
        }

        public async Task<List<Trainer>> GetAllTrainersWithSkills()
        {
            return await _unitOfWork.Trainers.GetAllTrainersLoaded();
        }

        public async Task<Trainer> GetTrainerByIdWithSkills(int id)
        {
            return await _unitOfWork.Trainers.GetTrainerByIdLoaded(id);
        }      
    }   
}
