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
    public class ActorLogic : IActorLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActorLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateActor(ActorDTO actor)
        {
            bool check = false;
            if(actor != null)
            {
                Actor actorModel = new Actor()
                {
                    ActorId = actor.ActorId,
                    ActorName = actor.ActorName,
                    Image = actor.Image,
                    Description = actor.Description,
                    Phone = actor.Phone,
                    Email = actor.Email,
                    IsActive = true,
                };
                _unitOfWork.GetRepository<Actor>().Insert(actorModel);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
            
        }

        

        public bool DeleteActor(int id)
        {
            bool check = false;
            Actor actor = _unitOfWork.GetRepository<Actor>().FindById(id);
            if(actor != null)
            {
                actor.IsActive = false;
                _unitOfWork.GetRepository<Actor>().Update(actor);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public Actor GetActorById(int id)
        {
            Actor actor = _unitOfWork.GetRepository<Actor>().FindById(id);
            return actor;
        }

        public IQueryable<Actor> GetAllActors()
        {
            IQueryable<Actor> actorList = _unitOfWork.GetRepository<Actor>().GetAll();
            return actorList;
        }

        public bool UpdateActor(Actor actor)
        {
            bool check = false;
            if(actor != null)
            {
                _unitOfWork.GetRepository<Actor>().Update(actor);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
