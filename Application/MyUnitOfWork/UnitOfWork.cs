using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDDbContext;
using Infrastructucre.RepoImplementations;

namespace Application.MyUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudDbContext _cRUDDbContext;
        public UnitOfWork(CrudDbContext cRUDDbContext)
        {
            _cRUDDbContext = cRUDDbContext;
            Skills = new SkillRepository(_cRUDDbContext);
            Trainers = new TrainerRepository(_cRUDDbContext);
        }
        public ISkillsRepository Skills { get; private set; }
        public ITrainerRepository Trainers { get; private set; }
        public bool Save()
        {
            try
            {
                _cRUDDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            { 
                return false;
            }
        }
    }
}
