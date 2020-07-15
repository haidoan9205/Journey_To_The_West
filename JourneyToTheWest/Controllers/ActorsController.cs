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
            return Ok(actor);
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
            return Ok(actor);
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

        [HttpPut]
        public IActionResult UpdateActor(Actor actor)
        {
            
            if (actor == null)
            {
                return BadRequest();
            }
            bool check = _actorLogic.UpdateActor(actor);
            return Ok(actor);

        }



        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            Actor actor = _actorLogic.GetActorById(id);
            var check = _actorLogic.DeleteActor(id);
            if (!check)
            {
                return BadRequest("Error: Remove Fail");
            }
            return Ok(actor);
        }
    }
}
