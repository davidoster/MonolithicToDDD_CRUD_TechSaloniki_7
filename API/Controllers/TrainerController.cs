using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using CRUDDbContext;
using Microsoft.EntityFrameworkCore;
using Infrastructucre.RepoImplementations;
using Application.ServiceInterface;
using Newtonsoft.Json;
using Application.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // /api/Trainer/GetAllTrainers
        [HttpGet("GetAllTrainers")]
        public async Task<IActionResult> GetTrainers()
        {
            var response = await _trainerService.GetAllTrainers();
            var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        [HttpGet("GetTrainerById")]
        public async Task<IActionResult> GetTrainerById(int trainerId)
        {
            try
            {
                var response = await _trainerService.GetTrainerById(trainerId);
                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Ok(json);
            }
            catch (Exception)
            {
                return Content("This trainer does not exist in our database");
            } 
        }

        [HttpPost("CreateNewTrainer")]
        public async Task<IActionResult> CreateTrainer(Trainer trainer)
        {
            var response = await _trainerService.Create(trainer);
            return Ok(response);
        }

        [HttpPut("Updatetrainer")]
        public async Task<IActionResult> UpdateTrainer([FromBody] Trainer trainer)
        {
            //var response = await _trainerService.Update(trainer);
            var response = await _trainerService.Update(trainer);
            return Ok(response);
        }



        [HttpDelete("DeleteTrainer")]
        public async Task<ActionResult> DeleteTrainer(int trainerId)
        {
            var response = await _trainerService.Delete(trainerId);
            return Ok(response);
        }







        //---------------------------------------------------------------------------




        //        int? employeeNameLength = employee?.Name?.Length;
        //            if (employeeNameLength< 3 || employeeNameLength> 30)
        //            {
        //                return BadRequest("Name should be between 3 and 30 characters.");
        //    }

        //    await _repository.AddEmployeeAsync(employee);

        //            return CreatedAtAction(nameof(GetById), new { id = employee?.Id
        //}, employee);




        //     {
        //"id": 0,
        //"firstName": "Petros",
        //"lastName": "Petras",
        //"email": "Petros@example.com",
        //"phoneNumber": "88888888888",
        //"skills": [
        // {
        //  "id": 9,
        //  "name": "345345",
        //  "description": "345345"
        //},
        //{
        //  "id": 10,
        //  "name": "fdgdfg",
        //  "description": "dfgfd"
        //}


    }
}
