using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;

namespace LaptopsSystem.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        //void Update(T entity);
        //void Update(T entity, params string[] excludProp);
        void Update(T entity, params Expression<Func<T, object>>[] excludProp);

        void Delete(T entity);

        void Delete(object id);

        void Detach(T entity);
    }
}
