using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctors();

        Doctor getDoctor(long id);

        List<Doctor> GetAllDoctorsFromHospital(long hospital_id);
    }
}
