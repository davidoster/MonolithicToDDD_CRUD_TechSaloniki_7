using RepoInterfaces;

namespace UnitOfWork {
    public interface IUnitOfWork 
    {
        ISkillsRepository Skill { get; }
    }
}