using BLL.DTOs.CalamityDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICalamityLogic
    {
        public IQueryable<Calamity> GetAllCalamities();
        public Calamity GetCalamityById(int id);
        // public List<NewsViewModel> SearchNewsByTitle(String title, PagingModel pagingModel);
        public bool CreateCalamity(Calamity calamity);
        public bool UpdateCalamity(Calamity calamity);
        public bool DeleteCalamity(int id);
    }
}
