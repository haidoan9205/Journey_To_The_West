using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IEquipmentLogic
    {
        public IQueryable<Equipment> GetAllEquipments();
        public Equipment GetEquipmentById(int id);
        // public List<NewsViewModel> SearchNewsByTitle(String title, PagingModel pagingModel);
        public bool CreateEquipment(EquipmentDTO equipment);
        public bool UpdateEquipment(Equipment equipment);
        public bool DeleteEquipment(int id);
    }
}
