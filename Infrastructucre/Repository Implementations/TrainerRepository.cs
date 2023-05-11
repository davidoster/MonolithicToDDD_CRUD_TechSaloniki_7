using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDDbContext;
using Microsoft.EntityFrameworkCore;
using Models;
using RepoInterfaces;

namespace Infrastructucre.RepoImplementations
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly CrudDbContext _dbContext;

        public TrainerRepository(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddTrainer(Trainer trainer)
        {
            try
            {
                await _dbContext.Trainers.AddAsync(trainer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveTrainer(int id)
        {
            var objToRemove = await GetTrainerById(id);
            try
            {
                _dbContext.Trainers.Remove(objToRemove);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<List<Trainer>> GetAllTrainers()
        {
            try
            {
                return await _dbContext.Trainers.ToListAsync();
            }
            catch(Exception)
            {
                return new List<Trainer>(); 
            }
        }
        public async Task<List<Trainer>> GetAllTrainersLoaded()
        {
            try
            {
                return await _dbContext.Trainers.Include(x => x.Skills).ToListAsync();
            }
            catch(Exception)
            {
                return new List<Trainer>(); 
            }
        }

        public async Task<Trainer>GetTrainerById(int id)
        {
            try
            {
                return await _dbContext.Trainers.Include(x => x.Skills).SingleAsync(x => x.Id == id);
            }
            catch(Exception) 
            {
                throw new Exception("Invalid Trainer Id");
            }
        }
        public async Task<Trainer> GetTrainerByIdLoaded(int id)
        {
            try
            {
                return await _dbContext.Trainers.Include(x => x.Skills).SingleAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception("Invalid Trainer Id");
            }
        }
    }
}
