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
            IDoctorService doctorService = new DoctorService();
            IHospitalService hospitalService = new HospitalService();
            string response = WebService.getInstance().GetVisitationByPatientID(patientId);

            if (response.Equals("{}"))
            {
                return new List<ScheduledVisitation>();
            }
            
            List<ScheduledVisitation> visits = JsonConvert.DeserializeObject<List<ScheduledVisitation>>(response);

            foreach (ScheduledVisitation visitation in visits)
            {
                HospitalModel hospital = hospitalService.GetHispital(visitation.HospitalId);
                Doctor doctor = doctorService.getDoctor(visitation.DoctorId);
                visitation.Hospital = hospital;
                visitation.Doctor = doctor;
                
            }
            return visits;
        }

        public bool AddNewScheduleVisitation(ScheduledVisitation visitatin)
        {
            return true;
        }
    }
}
