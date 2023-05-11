using Models;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface ITrainerService
    {
        public Task<List<Trainer>> GetAllTrainers();
        public Task<Trainer> GetTrainerById(int id);
        public Task<List<Trainer>> GetAllTrainersWithSkills();
        public Task<Trainer> GetTrainerByIdWithSkills(int id);
        public Task<bool> Create(Trainer trainer);
        public Task<bool> Delete(int trainerId);
        public Task<bool> Update(Trainer trainer);
    }
}
