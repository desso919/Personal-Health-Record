using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Models
{
    public class Template
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public Patient Patient { get; set; }

        public HospitalModel Hospital { get; set; }

        public Doctor Doctor { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public string Description { get; set; }

        public Template Clone()
        {
            Template cloneObject = new Template();
            cloneObject.Id = Id;
            cloneObject.Title = Title;
            cloneObject.PatientId = PatientId;
            cloneObject.HospitalId = HospitalId;
            cloneObject.DoctorId = DoctorId;
            cloneObject.Patient = Patient;
            cloneObject.Hospital = Hospital;
            cloneObject.Doctor = Doctor;
            cloneObject.Reason = Reason;
            cloneObject.Description = Description;
            return cloneObject;
        }
    }
}
