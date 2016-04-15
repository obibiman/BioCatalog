﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        long Count();
        //
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        //Task<IEnumerable<T>> GetAllEntitiesFiltered(Expression<Func<T, bool>> predicate = null);
        //Task<IEnumerable<T>> GetAllEntities();
        //Task<T> GetEntity(Expression<Func<T, bool>> predicate);
        //Task<T> GetEntityById(int Id);
        //Task CountEntity();
        //Task DeleteEntity(T entity);
        //Task UpdateEntity(T entity);
        //Task AddEntity(T entity);
        //asyncs
    }
}