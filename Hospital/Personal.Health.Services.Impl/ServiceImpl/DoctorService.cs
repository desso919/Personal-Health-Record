using Hospital.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;
using System.Threading.Tasks;


namespace Personal.Health.Services.Impl
{
    public class DoctorService : IDoctorService 
    {
        public List<Doctor> GetAllDoctors()
        {
           string result = WebService.getInstance().GetAllDoctors();
           return JsonConvert.DeserializeObject<List<Doctor>>(result);
        }

        public Doctor getDoctor(long id)
        {
            string result = WebService.getInstance().GetDoctor(id);
            return JsonConvert.DeserializeObject<Doctor>(result);
        }

        public List<Doctor> GetAllDoctorsFromHospital(long hospital_id)
        {
            string result = WebService.getInstance().GetDoctorsByHospitalId(hospital_id);
            return JsonConvert.DeserializeObject<List<Doctor>>(result);
        }
    }
}
