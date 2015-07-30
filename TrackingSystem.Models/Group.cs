using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Models
{
    public class Group
    {
        private ICollection<Student> students;

        public Group()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public virtual Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public double MaxDistance { get; set; }
    }
}
