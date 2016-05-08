using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class History
    {
        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public HospitalModel HospitalObject { get; set; }

        public Doctor DoctorObject { get; set; }

        public string Hospital { get; set; }

        public string Doctor { get; set; }

        public string Reason { get; set; }

        public string Diagnose { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }
}
