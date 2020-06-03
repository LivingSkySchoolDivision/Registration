using LSSD.Registration.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LSSD.Registration.Data
{
    interface IRepository<T> where T : IGUIDable
    {
        Guid Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> Find(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        T GetById(Guid id);
    }
}
