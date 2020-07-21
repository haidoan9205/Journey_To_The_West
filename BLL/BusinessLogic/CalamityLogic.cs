using BLL.DTOs.CalamityDTOs;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BusinessLogic
{
    public class CalamityLogic : ICalamityLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public CalamityLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateCalamity(CalamityViewDTO calamity)
        {
            bool check = false;
            if(calamity != null)
            {
                Calamity calamityModel = new Calamity()
                {
                    //CalamityId = calamity.CalamityId,
                    CalamityName = calamity.CalamityName,
                    Description = calamity.Description,
                    Location = calamity.Location,
                    StartTime = calamity.StartTime,
                    EndTime = calamity.EndTime,
                    NumberOfFilming = calamity.NumberOfFilming,
                    RoleSpecification = calamity.RoleSpecification,
                    Status = calamity.Status,
                    IsActive = true,
                };
                _unitOfWork.GetRepository<Calamity>().Insert(calamityModel);
                _unitOfWork.Commit();
                check = true;
                
            }
            return check;
        }

        public bool DeleteCalamity(int id)
        {
            bool check = false;
            Calamity calamity = _unitOfWork.GetRepository<Calamity>().FindById(id);
            if(calamity != null)
            {
                calamity.IsActive = false;
                _unitOfWork.GetRepository<Calamity>().Update(calamity);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<Calamity> GetAllCalamities()
        {
            IQueryable<Calamity> calamities = _unitOfWork.GetRepository<Calamity>().GetAll()
                .Where(calamity => calamity.IsActive == true);
            return calamities;
        }

        public Calamity GetCalamityById(int id)
        {
            Calamity calamity = _unitOfWork.GetRepository<Calamity>().FindById(id);
            return calamity;
        }

        public bool UpdateCalamity(Calamity calamity)
        {
            bool check = false;
            if(calamity != null)
            {
                _unitOfWork.GetRepository<Calamity>().Update(calamity);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
