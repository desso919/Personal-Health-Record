﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ScheduledVisitation
    {
        public long VisitationId { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public string Reason { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
