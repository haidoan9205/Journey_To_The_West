﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();

        T FindById(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
