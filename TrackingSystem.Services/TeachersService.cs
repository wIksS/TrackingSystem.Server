using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Data;
using TrackingSystem.Models;
using TrackingSystem.Services.Contracts;

namespace TrackingSystem.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly ITrackingSystemData data;

        public TeachersService(ITrackingSystemData data)
        {
            this.data = data;
        }

        public IEnumerable<Teacher> GetAll()
        {
            var teachers = this.data.Teachers.All();

            return teachers;
        }

        public Teacher Get(string id)
        {
            return data.Teachers.Find(id);
        }
    }
}
