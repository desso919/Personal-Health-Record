using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl
{
    public class VisitationService : IVisitationService
    {
        public bool AddNewScheduleVisitation(ScheduledVisitation visitatin)
        {
            return true;
        }

        public List<ScheduledVisitation> getAllScheduledVisitation()
        {
            List<ScheduledVisitation> visitations = new List<ScheduledVisitation>();
            ScheduledVisitation visitation = new ScheduledVisitation();

            visitation.DoctorId = 1;
            visitation.HospitalId = 2;
            visitation.Date = new DateTime();
            visitation.Description = "Pregled";
            visitation.Reason = "Sifilis";
            visitations.Add(visitation);
            return visitations;
        }
    }
}
