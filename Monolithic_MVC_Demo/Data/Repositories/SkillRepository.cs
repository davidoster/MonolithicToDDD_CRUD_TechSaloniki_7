using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monolithic_MVC_Demo.Data;
using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.RepoInterfaces;
using Monolithic_MVC_Demo.Services;

public class SkillRepository : ISkillRepository
{
    private readonly WebAppDbContext _dbContext;

    public SkillRepository(WebAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Skill GetSkillById(int id)
    {
        return _dbContext.Skills.Include(x => x.Trainers).Single(x => x.Id==id);

    }

    public List<Skill> GetAllSkills()
    {
        return _dbContext.Skills
            .Include(s => s.Trainers)
            .ToList();
    }

    public void AddSkill(Skill skill)
    {
        _dbContext.Skills.Add(skill);
        _dbContext.SaveChanges();
    }

    public void UpdateSkill(Skill skill)
    {
        _dbContext.Skills.Update(skill);
        _dbContext.SaveChanges();
    }

    public void DeleteSkill(int id)
    {
        var skillToDelete = GetSkillById(id);

        if (skillToDelete != null)
        {
            _dbContext.Skills.Remove(skillToDelete);
            _dbContext.SaveChanges();
        }
    }
}

