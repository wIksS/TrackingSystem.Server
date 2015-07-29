using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Models
{
    public class Teacher : ApplicationUser
    {
        private ICollection<Student> students;

        public Teacher()
        {
            this.Students = new HashSet<Student>();
        }

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

        public override KeyValuePair<string, double> CalculateDistance()
        {
            throw new NotImplementedException();
        }
    }
}
