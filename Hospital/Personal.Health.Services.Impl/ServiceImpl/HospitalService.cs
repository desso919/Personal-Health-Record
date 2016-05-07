using Hospital.Models;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;
using System.Collections.Generic;
using System.Linq;

namespace Personal.Health.Services.Impl
{
    public class HospitalService : IHospitalService
    {
        public List<HospitalModel> GetAllHispitals()
        {
            return JsonConvert.DeserializeObject<List<HospitalModel>>(WebService.getInstance().GetAllHospitals());
        }

        public HospitalModel GetHispital(long id)
        {
            return JsonConvert.DeserializeObject<HospitalModel>(WebService.getInstance().GetHospital(id));
        }
    }
}
