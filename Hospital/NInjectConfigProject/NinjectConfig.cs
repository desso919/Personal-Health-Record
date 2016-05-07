using Ninject;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NInjectConfigProject
{
    public class NinjectConfig
    {
        public static IKernel Container { get; private set; }

        public static void ConfigureContainer()
        {
            Container = new StandardKernel();
            Container.Bind<IPatientService>().To<PatientService>().InTransientScope();
            Container.Bind<IHospitalService>().To<HospitalService>().InTransientScope();
            Container.Bind<IDoctorService>().To<DoctorService>().InTransientScope();
            Container.Bind<IHistoryService>().To<HistoryService>().InTransientScope();
            Container.Bind<IVisitationService>().To<VisitationService>().InTransientScope();
        }
    }
}
