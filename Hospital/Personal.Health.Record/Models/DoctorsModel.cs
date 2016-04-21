using Hospital.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Record.Models
{
    public class DoctorsModel
    {
       public List<Doctor> getDoctors()
        {
            IDoctorService doctorService = new DoctorService();
            List<Doctor> doctors = doctorService.getAllDoctors();
            return doctors;
        }
      
    }
}
