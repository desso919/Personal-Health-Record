using Hospital.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;
using System.Threading.Tasks;


namespace Personal.Health.Services.Impl
{
    public class DoctorService : IDoctorService 
    {
        public async Task<List<Doctor>> GetAllDoctors()
        {
           string result = await WebService.getInstance().GetAllDoctorsAsync();
           return JsonConvert.DeserializeObject<List<Doctor>>(result);
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
