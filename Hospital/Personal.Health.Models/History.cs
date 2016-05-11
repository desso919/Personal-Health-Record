using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class History
    {
        public Patient Patient { get; set; }

        public HospitalModel Hospital{ get; set; }

        public Doctor Doctor { get; set; }

        public string Reason { get; set; }

        public string Diagnose { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }
}
