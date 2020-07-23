using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.CalamityDTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JourneyToTheWest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalamitiesController : ControllerBase
    {
        private readonly Journey_To_The_WestContext _context;

  

        private readonly ICalamityLogic _calamityLogic;
        public CalamitiesController(ICalamityLogic calamityLogic, Journey_To_The_WestContext context)
        {
            _calamityLogic = calamityLogic;
            _context = context;
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
            Calamity calamity = _calamityLogic.GetCalamityById(id);
            var check = _calamityLogic.DeleteCalamity(id);
            if (!check)
            {
                return BadRequest("Error: Remove Fail");
            }
            return Ok(calamity);
        }

        [HttpPut]
        public IActionResult UpdateCalamity([FromBody] Calamity calamity)
        {
            if (calamity == null)
            {
                return BadRequest();
            }
            bool check = _calamityLogic.UpdateCalamity(calamity);
            return Ok(calamity);
        }

    }
}
