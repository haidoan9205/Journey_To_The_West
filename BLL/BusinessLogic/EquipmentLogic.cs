using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BusinessLogic
{
    public class EquipmentLogic : IEquipmentLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipmentLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateEquipment(EquipmentDTO equipment)
        {
            bool check = false;
            if(equipment != null)
            {
                Equipment equipmentModel = new Equipment()
                {
                    EquipmentId = equipment.EquipmentId,
                    EquipmentName = equipment.EquipmentName,
                    Description = equipment.Description,
                    Quantity = equipment.Quantity,
                    Image = equipment.Image,
                    IsActive = true,
                };
                _unitOfWork.GetRepository<Equipment>().Insert(equipmentModel);
                _unitOfWork.Commit();
                check = true; 
                
               
            }
            return check;
        }

        public bool DeleteEquipment(int id)
        {
            bool check = false;
            Equipment equipmentModel = _unitOfWork.GetRepository<Equipment>().FindById(id);
            if(equipmentModel != null)
            {
                equipmentModel.IsActive = false;
                _unitOfWork.GetRepository<Equipment>().Update(equipmentModel);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<Equipment> GetAllEquipments()
        {
            IQueryable<Equipment> equipmentList = _unitOfWork.GetRepository<Equipment>().GetAll();
            return equipmentList;
        }

        public Equipment GetEquipmentById(int id)
        {
            Equipment equipmentModel = _unitOfWork.GetRepository<Equipment>().FindById(id);
            return equipmentModel;
        }

        public bool UpdateEquipment(Equipment equipment)
        {
            bool check = false;
            if(equipment != null)
            {
                _unitOfWork.GetRepository<Equipment>().Update(equipment);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
