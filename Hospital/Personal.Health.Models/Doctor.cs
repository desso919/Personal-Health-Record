using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctor
    {
        public long DoctorId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Specialization { get; set; }

        public int Rating { get; set; }

        public string Name
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public string ShowDoctor
        {
            get { return string.Format("{0} {1}          {2}", FirstName, LastName, Specialization); }
        }
    }
}
