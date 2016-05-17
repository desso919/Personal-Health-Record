using Personal.Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class History
    {
        private DateTime date;

        public long Id { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public Patient Patient { get; set; }

        public HospitalModel Hospital { get; set; }

        public Doctor Doctor { get; set; }

        public string Diagnose { get; set; }

        public string Reason { get; set; }

        public string Date
        {
            get { return Utill.formatDate(date); }
            set { date = Convert.ToDateTime(value); }
        }

        public string Description { get; set; }

        public History Clone()
        {
            History cloneObject = new History();
            cloneObject.Id = Id;
            cloneObject.PatientId = PatientId;
            cloneObject.HospitalId = HospitalId;
            cloneObject.DoctorId = DoctorId;
            cloneObject.Patient = Patient;
            cloneObject.Hospital = Hospital;
            cloneObject.Doctor = Doctor;
            cloneObject.Date = Date;
            cloneObject.Diagnose = Diagnose;
            cloneObject.Reason = Reason;
            cloneObject.Description = Description;
            return cloneObject;
        }
    }
}
