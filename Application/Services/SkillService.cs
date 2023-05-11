using Application.MyUnitOfWork;
using Application.ServiceInterface;
using Models;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Skill>> GetAllSkills()
        {           
            return await _unitOfWork.Skills.GetAllSkills();
        }

        public async Task<List<Skill>> GetAllSkillsWithTrainers()
        {
            return await _unitOfWork.Skills.GetAllSkillsLoaded();
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await _unitOfWork.Skills.GetSkillById(id);
        }

        public async Task<Skill> GetSkillByIdWithTrainers(int id)
        {
            return await _unitOfWork.Skills.GetSkillById(id);
        }

        public async Task<bool> Create(Skill skill)
        {
            if(skill.Trainers != null)
            {
                List<Trainer> trainers = new();
                foreach(var tariner in skill.Trainers)
                {
                    trainers.Add(await _unitOfWork.Trainers.GetTrainerById(tariner.Id));
                }
                skill.Trainers = trainers;          
            }
            var response = await _unitOfWork.Skills.AddSkill(skill);
            _unitOfWork.Save();
            return response;
        }
        
        public async Task<bool> Update(Skill skill)
        {
            try
            {
                var existingSkill = await _unitOfWork.Skills.GetSkillByIdLoaded(skill.Id);
                List<Trainer> newTrainers = new();
                if(skill.Trainers != null)
                {
                    foreach(var tariner in skill.Trainers)
                    {
                        newTrainers.Add(await _unitOfWork.Trainers.GetTrainerByIdLoaded(tariner.Id));
                    }
                }
                existingSkill.Trainers?.Clear();
                existingSkill.Trainers = newTrainers;
                existingSkill.Name = skill.Name;
                existingSkill.Description = skill.Description;
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int skillId)
        {
            var response = await _unitOfWork.Skills.RemoveSkill(skillId);
            _unitOfWork.Save();
            return response;
        }

    }
}
