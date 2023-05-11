using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MyUnitOfWork
{
    public interface IUnitOfWork
    {
        ISkillsRepository Skills { get; }
        ITrainerRepository Trainers { get; }
        bool Save();
    }
}
