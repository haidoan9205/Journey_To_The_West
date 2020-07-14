using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace JourneyToTheWest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentLogic _equipmentLogic;
        public EquipmentsController(IEquipmentLogic equipmentLogic)
        {
            _equipmentLogic = equipmentLogic;
        }

        [HttpGet("{id}")]
        public IActionResult GetEquipment(int id)
        {
            Equipment equipment = _equipmentLogic.GetEquipmentById(id);
            if (equipment == null)
            {
                return NotFound("Equipment is not found");
            }
            return Ok(equipment);
        }

        [HttpGet]
        public IActionResult GetAllEquipments()
        {
            List<Equipment> equipment = _equipmentLogic.GetAllEquipments().ToList();
            if (equipment == null)
            {
                return BadRequest("Error");
            }
            if (equipment.Count == 0)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        [HttpPost]
        public IActionResult CreateEquipment(EquipmentDTO equipment) 
        {
            if(equipment == null)
            {
                return BadRequest("null");
            }
            bool check = _equipmentLogic.CreateEquipment(equipment);
            if (!check)
            {
                return BadRequest("Cannot create an equipment");
            }
            return Ok("Success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEquipment(int id)
        {
            var check = _equipmentLogic.DeleteEquipment(id);
            if (!check)
            {
                return BadRequest("Error: Remove Fail");
            }
            return Ok("Remove Successfully");
        }

        [HttpPost("{id}")]
        public IActionResult UpdateEquipment([FromBody] Equipment equipment)
        {
            Equipment equipmentModel = _equipmentLogic.GetEquipmentById(equipment.EquipmentId);
            if(equipment == null)
            {
                return NoContent();
            }
            equipmentModel.EquipmentId = equipment.EquipmentId;
            equipmentModel.EquipmentName = equipment.EquipmentName;
            equipmentModel.Description = equipment.Description;
            equipmentModel.Quantity = equipment.Quantity;
            equipmentModel.IsActive = true;
            return Ok("Updated Successfully");
        }
    }
}
