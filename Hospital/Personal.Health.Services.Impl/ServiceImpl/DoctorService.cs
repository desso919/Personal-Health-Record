using Hospital.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;


namespace Personal.Health.Services.Impl
{
    public class DoctorService : IDoctorService 
    {
        public List<Doctor> GetAllDoctors()
        {
           return JsonConvert.DeserializeObject<List<Doctor>>(WebService.getInstance().GetAllDoctors());
        }

        public Doctor getDoctor(long id)
        {
            return JsonConvert.DeserializeObject<Doctor>(WebService.getInstance().GetDoctor(id));
        }

        public List<Doctor> GetAllDoctorsFromHospital(long hospital_id)
        {
            return JsonConvert.DeserializeObject<List<Doctor>>(WebService.getInstance().GetDoctorsByHospitalId(hospital_id));
        }
    }
}
