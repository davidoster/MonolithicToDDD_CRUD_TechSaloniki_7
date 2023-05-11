using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CRUDDbContext;
using Microsoft.EntityFrameworkCore;
using Models;
using RepoInterfaces;




namespace Infrastructucre.RepoImplementations
{
    public class SkillRepository : ISkillsRepository
    {
        private readonly CrudDbContext _dbContext;
        public SkillRepository(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddSkill(Skill skill)
        {
            try
            {
                await _dbContext.Skills.AddAsync(skill);
                return  true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            try
            {
                return await _dbContext.Skills.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Skill>();
            }
        }
        public async Task<List<Skill>> GetAllSkillsLoaded()
        {
            try
            {
                return await _dbContext.Skills.Include(x => x.Trainers).ToListAsync();
            }
            catch (Exception)
            {
                return new List<Skill>();
            }
        }

        public async Task<Skill>GetSkillById(int id)
        {
                var temp = _dbContext.Skills.SingleOrDefaultAsync(x => x.Id == id);

            if (await temp != null )
            {
                return await temp;
            }
            else
            {
                throw new Exception();
            }
        }
        public async Task<Skill>GetSkillByIdLoaded(int id)
        {
            try
            {
                return await _dbContext.Skills.Include(x => x.Trainers).SingleAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception("Invalid Skill Id");
            }
        }

        public async Task<List<Skill>> GetSkillsByTrainerId(int id)
        {        
            return await _dbContext.Skills.Where(x => x.Trainers.Any(y => y.Id == id)).ToListAsync();
        }

        public async Task<bool> RemoveSkill(int id)
        {
            var objToRemove = await GetSkillById(id);
            try
            {
                _dbContext.Skills.Remove(objToRemove);
                return true;
            }
            catch (Exception)
            {
                return false;
            }          
        }
    }
}
