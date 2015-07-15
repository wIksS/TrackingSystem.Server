using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T Find(object id);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}
