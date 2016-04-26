using Hospital.Models;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.HospitalServiceReference;
using Personal.Health.Services.Impl.ServiceImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl
{
    public class VisitationService : IVisitationService
    {
        public ScheduledVisitation GetVisitation(long id)
        {
            return JsonConvert.DeserializeObject<ScheduledVisitation>(WebService.getInstance().GetVisitation(id));
        }

        public List<ScheduledVisitation> GetAllScheduledVisitationsForThisPatient(long patientId)
        {
            string response = WebService.getInstance().GetVisitationByPatientID(patientId);
            if(response.Equals("{}")) {
                return new List<ScheduledVisitation>();
            }
            List<ScheduledVisitation> visits = JsonConvert.DeserializeObject<List<ScheduledVisitation>>(response);
            return visits;
        }

        public List<ScheduledVisitation> GetAllScheduledVisitationsByHospital(long hospitalId)
        {
            return JsonConvert.DeserializeObject<List<ScheduledVisitation>>(WebService.getInstance().GetVisitationByHospitalID(hospitalId));
        }

        public List<ScheduledVisitation> GetAllScheduledVisitationsByDoctor(long doctorId)
        {
            return JsonConvert.DeserializeObject<List<ScheduledVisitation>>(WebService.getInstance().GetVisitationByDoctorID(doctorId));
        }

        public bool AddNewScheduleVisitation(ScheduledVisitation visitatin)
        {
            return true;
        }
    }
}
