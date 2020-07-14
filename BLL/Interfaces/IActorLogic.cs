using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    public interface IActorLogic
    {
        public IQueryable<Actor> GetAllActors();
        public Actor GetActorById(int id);
       // public List<NewsViewModel> SearchNewsByTitle(String title, PagingModel pagingModel);
        public bool CreateActor(ActorDTO actor);
        public bool UpdateActor(Actor actor);
        public bool DeleteActor(int id);
    }
}
