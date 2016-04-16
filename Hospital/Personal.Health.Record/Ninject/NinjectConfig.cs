using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Ninject;

namespace Personal.Health.Record.Ninject
{
    
    using Personal.Health.Services;
    using Personal.Health.Services.Impl;
    using System.Windows;

    public static class NinjectConfig
    {
        private static IKernel container;

        public static void ConfigureContainer()
        {
            container = new StandardKernel();
            container.Bind<IPatientService>().To<PatientService>().InTransientScope();
            container.Bind<IHospitalService>().To<HospitalService>().InTransientScope();
            container.Bind<IDoctorService>().To<DoctorService>().InTransientScope();
            container.Bind<IHistoryService>().To<HistoryService>().InTransientScope();
            container.Bind<IVisitationService>().To<VisitationService>().InTransientScope();
        }

        public static void ComposeObjects(Application current)
        {
            current.MainWindow = container.Get<MainWindow>();
        }
    }
}
