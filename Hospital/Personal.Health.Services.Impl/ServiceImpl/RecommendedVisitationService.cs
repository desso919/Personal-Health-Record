using Newtonsoft.Json;
using Personal.Health.Models;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl.ServiceImpl
{
    public class RecommendedVisitationService : IRecommendedVisitationService
    {
        public RecommendedVisitation GetRecommendedVisitation(long id)
        {
            return JsonConvert.DeserializeObject<RecommendedVisitation>(WebService.getInstance().GetRecommendedVisitation(id));
        }

        public List<RecommendedVisitation> GetRecommendedVisitationForPatient(int age)
        {
            string response = WebService.getInstance().GetRecommendedVisitationForPatient(age);

            if (response.Equals(ServicesUtils.EMPTY_JSON))
            {
                return new List<RecommendedVisitation>();
            }

            List<RecommendedVisitation> visitations = JsonConvert.DeserializeObject<List<RecommendedVisitation>>(response);
            return visitations;
        }
    }
}
