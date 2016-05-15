using Hospital.Models;
using Personal.Health.Care.DesktopApp.ViewModels;
using Personal.Health.Models;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NInjectConfigProject;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using Personal.Health.Services;

namespace Personal.Health.Care.DesktopApp.Model
{
    public class MediatorClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static ScheduledVisitation visitation = new ScheduledVisitation();
        private static ICommand saveCommand;
        private static ICommand saveTemplateCommand;
        private static Template template;


        private static List<ScheduledVisitation> visitations;
        private static List<History> history;
        private static List<Template> templates;
        private static List<HospitalModel> hospitals;
        private static List<Doctor> doctors;


        private static IVisitationService visitationService;
        private static ITemplateService templateService;
        private static IHistoryService historyService;
        private static IHospitalService hospitalService;
        private static IDoctorService doctorService;

        public static MediatorClass instance = new MediatorClass();

        public static MediatorClass GetInstance() {
            if (instance == null)
            {
                instance =  new MediatorClass();     
            }
            return instance;
        }

        public static Template SelectedTemplate { get { return template; } set { template = value; } }




        #region in use
        public static ScheduledVisitation SelectedVisitation { get { return visitation; } set { visitation = value; } }

        public static ICommand SaveCommand { get { return saveCommand; } set { saveCommand = value; } }
        public static ICommand SaveTemplateCommand { get { return saveTemplateCommand; } set { saveTemplateCommand = value; } }

        public static List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; } }
        public static List<History> Histories { get { return history; } set { history = value; } }
        public static List<Template> Templates { get { return templates; } set { templates = value; } }
        public static List<HospitalModel> Hospitals { get { return hospitals; } set { hospitals = value; } }
        public static List<Doctor> Doctors { get { return doctors; } set { doctors = value; } }



        public static async void Init() {

            long thisPatientId = LoggedInPatient.GetPatient().Id;
            visitationService = NinjectConfig.Container.Get<IVisitationService>();
            templateService = NinjectConfig.Container.Get<ITemplateService>();
            historyService = NinjectConfig.Container.Get<IHistoryService>();
            hospitalService = NinjectConfig.Container.Get<IHospitalService>();
            doctorService = NinjectConfig.Container.Get<IDoctorService>();            

            Templates = templateService.GetAllPatientTemplates(thisPatientId);
            Visitations = visitationService.GetAllScheduledVisitationsForThisPatient(thisPatientId);
            Histories = historyService.GetAllHistoryForThisPatient(thisPatientId);
            Hospitals = hospitalService.GetAllHispitals();
            Doctors = await doctorService.GetAllDoctors();

            int a = 2;
        }

        #endregion

        #region INotifyPropertyChanged
        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
        #endregion

      

    }
}
