using Hospital.Models;
using Newtonsoft.Json;
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

            if (response.Equals(ServicesUtils.EMPTY_JSON))
            {
                return new List<ScheduledVisitation>();
            }
            
            List<ScheduledVisitation> visits = JsonConvert.DeserializeObject<List<ScheduledVisitation>>(response);
            return visits;
        }

        public bool AddNewScheduleVisitation(ScheduledVisitation visitatin)
        {
            bool isAdded = WebService.getInstance().AddNewVisitation(visitatin.Patient.Id, visitatin.Hospital.HospitalId, visitatin.Doctor.DoctorId, visitatin.Date, visitatin.Reason, visitatin.Description);
            if (isAdded)
            {
                return true;
            }
            return false;
        }
    }
}
