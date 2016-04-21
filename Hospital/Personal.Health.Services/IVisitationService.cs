﻿using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services
{
    public interface IVisitationService
    {
        List<ScheduledVisitation> getAllScheduledVisitation();

        Boolean AddNewScheduleVisitation(ScheduledVisitation visitatin);
    }
}
