using Models;

namespace RepoInterfaces
{
    public interface ITrainerRepository
    {
        Task<List<Trainer>> GetAllTrainers();
        Task<Trainer> GetTrainerById(int id);
        Task<List<Trainer>> GetAllTrainersLoaded();
        Task<Trainer> GetTrainerByIdLoaded(int id);
        Task<bool> AddTrainer(Trainer trainer);
        Task<bool> RemoveTrainer(int id);
    }
}