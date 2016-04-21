using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl
{
    public class DoctorService : IDoctorService 
    {
        public List<Hospital.Models.Doctor> getAllDoctors()
        {
           Doctor doctor = new Doctor();
           doctor.FirstName = "Ros";
           doctor.SecondName = "Muci";
           doctor.LastName = "Geler";
            doctor.Specialization = "Brain Surgery";
           List<Doctor> doctors = new List<Doctor>();
           doctors.Add(doctor);
           return doctors;
        }
    }
}
