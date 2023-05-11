using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.RepoInterfaces;
using Monolithic_MVC_Demo.Services;

namespace Monolithic_MVC_Demo.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly ITrainerService _trainerService;

        public SkillController(ISkillService skillService, ITrainerService trainerService)
        {
            _skillService = skillService;
            _trainerService = trainerService;
        }

        public IActionResult Index()
        {
            var skills = _skillService.GetAllSkills();
            return View(skills);
        }

        public IActionResult Details(int id)
        {
            var skill = _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            _skillService.AddSkill(skill);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var skill = _skillService.GetSkillById(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            _skillService.UpdateSkill(skill);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var skill = _skillService.GetSkillById(id);
            return View(skill);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _skillService.DeleteSkill(id);
            return RedirectToAction("Index");
        }
    }
}
