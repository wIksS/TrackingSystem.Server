using TrackingSystem.Data.Repositories;
using TrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Data
{
    public class TrackingSystemData : ITrackingSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public TrackingSystemData()
            : this(new TrackingSystemDbContext())
        {
        }

        public TrackingSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Teacher> Teachers
        {
            get { return this.GetRepository<Teacher>(); }
        }

        public IRepository<Student> Students
        {
            get { return this.GetRepository<Student>(); }
        }

        public IRepository<Coordinate> Coordinates
        {
            get
            {
                return this.GetRepository<Coordinate>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
