using Hospital.Models;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl
{
    public class HospitalService : IHospitalService
    {
        public List<HospitalModel> GetAllHispitals()
        {
            string result = WebService.getInstance().GetAllHospitals();
            return JsonConvert.DeserializeObject<List<HospitalModel>>(result);
        }

        public HospitalModel GetHispital(long id)
        {
            return JsonConvert.DeserializeObject<HospitalModel>(WebService.getInstance().GetHospital(id));
        }
    }
}
