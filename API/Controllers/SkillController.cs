using CRUDDbContext;
using Infrastructucre.RepoImplementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using Application.ServiceInterface;
using Application.Services;
using Newtonsoft.Json;
using Azure;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        //GetAll - GetById
        #region

        // /api/Skill/GetSkills
        [HttpGet("GetAllSkills")]
        public async Task<IActionResult> GetSkills()
        {
            var responce = await _skillService.GetAllSkills();
            var json = JsonConvert.SerializeObject(responce, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        // /api/Skill/GetSkillById
        [HttpGet("GetSkillById")]
        public async Task<IActionResult> GetSkill(int id)
        {
            try
            {
                var response = await _skillService.GetSkillById(id);
                //if (response != null)
                //{
                    var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return Ok(json);
                //}
                //else
                //{
                //    return NotFound("Skill not found");
                //}
            }
            catch (Exception)
            {
                return Content("This skill does not exist in our database");
                //return BadRequest(e.Message);
            }
        }

        #endregion

        // /api/Skill/CreateNewSkill
        [HttpPost("CreateNewSkill")]
        public async Task<ActionResult> CreateSkill(Skill skill)
        {
           var response = await _skillService.Create(skill);
            return Ok(response);
        }

        // /api/Skill/UpdateSkill
        [HttpPut("UpdateSkill")]
        public async Task<ActionResult> UpdateSkill(Skill skill)
        {
            var response = await _skillService.Update(skill);
            return  Ok(response);
        }

        // /api/Skill/DeleteSkill
        [HttpDelete("DeleteSkill")]
        public async Task<ActionResult> DeleteSkill(int skillId)
        {
            var response = await _skillService.Delete(skillId);
            return Ok(response);
        }
    }
}
