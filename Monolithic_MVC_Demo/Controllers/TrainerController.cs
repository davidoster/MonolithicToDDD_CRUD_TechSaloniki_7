using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monolithic_MVC_Demo.Data;
using Monolithic_MVC_Demo.Models;
using Monolithic_MVC_Demo.RepoInterfaces;
using Monolithic_MVC_Demo.Services;

namespace Monolithic_MVC_Demo.Controllers
{
    
    public class TrainerController : Controller
    {

        private readonly ITrainerService _trainerService;
        private readonly ISkillService _skillService;

        public TrainerController(ITrainerService trainerService, ISkillService skillService)
        {
            _trainerService = trainerService;
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            var trainers = _trainerService.GetAllTrainers();
            return View(trainers);
        }

        public IActionResult Details(int id)
        {
            var trainer = _trainerService.GetTrainerById(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        public IActionResult Create()
        {
            ViewBag.Skills = new SelectList(_trainerService.GetAllSkills(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email,PhoneNumber")] Trainer trainer, int[] selectedValues)
        {
            
            _trainerService.AddTrainer(trainer, selectedValues);

            return RedirectToAction("Index");
        }

        

        public IActionResult Edit(int id)
        {
            var trainer = _trainerService.GetTrainerById(id);

            if (trainer == null)
            {
                return NotFound();
            }
            
            trainer.Skills ??= new List<Skill>();

            ViewBag.Skills = new SelectList(_skillService.GetAllSkills(), "Id", "Name", trainer.Skills.Select(s => s.Id));
            return View(trainer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber")] Trainer trainer, int[] Skills)
        {
            if (id != trainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                _trainerService.UpdateTrainer(trainer, Skills);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Skills = new SelectList(_skillService.GetAllSkills(), "Id", "Name", Skills);
            return View(trainer);
        }


        public IActionResult Delete(int id)
        {
            var trainer = _trainerService.GetTrainerById(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _trainerService.DeleteTrainer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
