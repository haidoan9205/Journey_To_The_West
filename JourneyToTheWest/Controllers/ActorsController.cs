using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JourneyToTheWest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorLogic _actorLogic;
        public ActorsController(IActorLogic actorLogic)
        {
            _actorLogic = actorLogic;
        }
        [HttpGet("{id}")]
        public IActionResult GetActor(int id)
        {
            Actor actor = _actorLogic.GetActorById(id);
            if (actor == null)
            {
                return NotFound("Actor is not found");
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllActors()
        {
            List<Actor> actor = _actorLogic.GetAllActors().ToList();
            if (actor == null)
            {
                return BadRequest("Error");
            }
            if (actor.Count == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateActor(ActorDTO actor)
        {
            if (actor == null)
            {
                return BadRequest("null");
            }
            bool check = _actorLogic.CreateActor(actor);
            if (!check)
            {
                return BadRequest("Cannot create an actor");
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor([FromBody] Actor actor)
        {
            Actor actorModel = _actorLogic.GetActorById(actor.ActorId);
            if (actorModel != null)
            {
                return NoContent();
            }
            actorModel.ActorName = actor.ActorName;
            actorModel.Image = actor.Image;
            actorModel.Description = actor.Description;
            actorModel.Phone = actor.Phone;
            return Ok();

        }



        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            var check = _actorLogic.DeleteActor(id);
            if (!check)
            {
                return BadRequest("Error: Remove Fail");
            }
            return Ok();
        }
    }
}
