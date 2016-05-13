using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ScheduledVisitation
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public Patient Patient { get; set; }

        public HospitalModel Hospital { get; set; }

        public Doctor Doctor { get; set; }

        public string Reason { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }
    }
}
