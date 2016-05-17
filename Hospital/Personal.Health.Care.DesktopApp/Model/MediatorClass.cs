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
        private static Task<List<HospitalModel>> taskHospitals;       
        private static ICommand saveCommand;
        private static ICommand okCommand;
        private static ICommand saveTemplateCommand;
        private static ICommand moveToVisitationCommand;
        private static Template template;

        private static List<ScheduledVisitation> visitations;
        private static List<History> history;
        private static List<Template> templates;
        private static List<HospitalModel> hospitals;
        private static List<Doctor> doctors;
        private static List<RecommendedVisitation> recommendedVisitation;

        public static MediatorClass instance = new MediatorClass();
        public static string diagnose;

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
        public static ICommand OKCommand { get { return okCommand; } set { okCommand = value; } }
        public static ICommand MoveToVisitationCommand { get { return moveToVisitationCommand; } set { moveToVisitationCommand = value; } }
        public static ICommand SaveTemplateCommand { get { return saveTemplateCommand; } set { saveTemplateCommand = value; } }
        public static List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; } }
        public static List<History> Histories { get { return history; } set { history = value; } }
        public static List<Template> Templates { get { return templates; } set { templates = value; } }
        public static List<RecommendedVisitation> RecommendedVisitation { get { return recommendedVisitation; } set { recommendedVisitation = value; } }

        public static List<HospitalModel> Hospitals { get { return hospitals; } set { hospitals = value; } }
        public static List<Doctor> Doctors { get { return doctors; } set { doctors = value; } }

        public static void Init()
        {
            long thisPatientId = LoggedInPatient.GetPatient().Id;

            hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
            doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors();
            //visitations = NinjectConfig.Container.Get<IVisitationService>().GetAllScheduledVisitationsForThisPatient(thisPatientId);
            //history = NinjectConfig.Container.Get<IHistoryService>().GetAllHistoryForThisPatient(thisPatientId);
            //templates = NinjectConfig.Container.Get<ITemplateService>().GetAllPatientTemplates(thisPatientId);
            recommendedVisitation = NinjectConfig.Container.Get<IRecommendedVisitationService>().GetRecommendedVisitationForPatient(Utills.Utill.GetAge(LoggedInPatient.GetPatient().BirhtDate));
        }

        public static void UpdatePatientTemplates()
        {
            templates = NinjectConfig.Container.Get<ITemplateService>().GetAllPatientTemplates(LoggedInPatient.GetPatient().Id);
        }

        public static void UpdatePatientVisitations()
        {
            visitations = NinjectConfig.Container.Get<IVisitationService>().GetAllScheduledVisitationsForThisPatient(LoggedInPatient.GetPatient().Id);
            sortVisitations();
        }

        public static void UpdatePatientHistory()
        {
            history = NinjectConfig.Container.Get<IHistoryService>().GetAllHistoryForThisPatient(LoggedInPatient.GetPatient().Id);
            sortHistory();
        }

        private static void sortVisitations() 
        {
            Comparison<ScheduledVisitation> comparator = new Comparison<ScheduledVisitation>((x,y)=>x.Date.CompareTo(y.Date));
            Visitations.Sort(comparator);
        }

        private static void sortHistory()
        {
            Comparison<History> comparator = new Comparison<History>((x, y) => x.Date.CompareTo(y.Date));
            Histories.Sort(comparator);
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
