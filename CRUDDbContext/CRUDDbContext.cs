using Microsoft.EntityFrameworkCore;
using Models;

namespace CRUDDbContext {
    public class CrudDbContext : DbContext {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {
            
        }       
    }
}