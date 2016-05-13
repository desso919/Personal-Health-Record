using Hospital.Models;
using Personal.Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.Model
{
    public static class MediatorClass
    {
        private static ScheduledVisitation visitation = new ScheduledVisitation();
        private static Template template;

        public static Template SelectedTemplate { get { return template; } set { template = value; } }

        public static ScheduledVisitation SelectedVisitation { get { return visitation; } set { visitation = value; } }

    }
}
