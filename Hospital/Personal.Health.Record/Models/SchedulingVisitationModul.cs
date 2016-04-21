using Hospital.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Record.Models
{
    public class SchedulingVisitationModul
    {
        public Boolean AddNewScheduleVisitation(ScheduledVisitation visitatin)
        {
            IVisitationService visitationService = new VisitationService();
            Boolean isAdded = visitationService.AddNewScheduleVisitation(visitatin);
            return isAdded;
        }
    }
}
