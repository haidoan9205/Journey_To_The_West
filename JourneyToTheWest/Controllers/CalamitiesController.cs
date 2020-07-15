using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.CalamityDTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JourneyToTheWest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalamitiesController : ControllerBase
    {
        private readonly ICalamityLogic _calamityLogic;
        public CalamitiesController(ICalamityLogic calamityLogic)
        {
            _calamityLogic = calamityLogic;
        }
        [HttpGet("{id}")]
        public IActionResult GetCalamity(int id)
        {
            Calamity calamity = _calamityLogic.GetCalamityById(id);
            if (calamity == null)
            {
                return NotFound("Calamity is not found");
            }
            return Ok(calamity);
        }

        [HttpGet]
        public IActionResult GetAllCalamities()
        {
            List<Calamity> calamity = _calamityLogic.GetAllCalamities().ToList();
            if (calamity == null)
            {
                return BadRequest("Error");
            }
            if (calamity.Count == 0)
            {
                return NotFound();
            }
            return Ok(calamity);
        }

        [HttpPost]
        public IActionResult CreateCalamity(CalamityViewDTO calamity)
        {
            if (calamity == null)
            {
                return BadRequest("null");
            }
            bool check = _calamityLogic.CreateCalamity(calamity);
            if (!check)
            {
                return BadRequest("Cannot create a calamity");
            }
            return Ok(calamity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCalamity(int id)
        {
            var check = _calamityLogic.DeleteCalamity(id);
            if (!check)
            {
                return BadRequest("Error: Remove Fail");
            }
            return Ok(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCalamity([FromBody] Calamity calamity)
        {
            //var check = 
            Calamity calamityModel = _calamityLogic.GetCalamityById(calamity.CalamityId); 
            if(calamityModel != null)
            {
                return NoContent();
            }
            calamityModel.CalamityId = calamity.CalamityId;
            calamityModel.CalamityName = calamity.CalamityName;
            calamityModel.Description = calamity.Description;
            calamityModel.Location = calamity.Location;
            calamityModel.StartTime = calamity.StartTime;
            calamityModel.EndTime = calamity.EndTime;
            calamityModel.NumberOfFilming = calamity.NumberOfFilming;
            calamityModel.RoleSpecification = calamity.RoleSpecification;
            calamityModel.Status = calamity.Status;

            return Ok();
        }

    }
}
