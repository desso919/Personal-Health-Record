using NInjectConfigProject;
using Personal.Health.Models;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Runtime.CompilerServices;
using Personal.Health.Care.DesktopApp.Utills;
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Pages.Views;
using Hospital.Models;
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Services;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class RecommendedVisitationsViewModel
    {
         public event PropertyChangedEventHandler PropertyChanged;
        List<RecommendedVisitation> visiations;
        private IRecommendedVisitationService service;
        private IVisitationService visitationService;
        private RecommendedVisitation selectedVisitation;
        private ICommand addToVisitationCommand;

        #region Constructor

        public RecommendedVisitationsViewModel()
        {
            service = NinjectConfig.Container.Get<IRecommendedVisitationService>();
            visitationService = NinjectConfig.Container.Get<IVisitationService>();
            addToVisitationCommand = new RelayCommand(AddToMyVisitations);
            ShowPatientRecommendedVisitation();
        }
        #endregion

        #region Properties

        public List<RecommendedVisitation> RecommendedVisiations { get { return visiations; } set { visiations = value; NotifyPropertyChanged(); } }

        public RecommendedVisitation SelectedVisitation { get { return selectedVisitation; } set { selectedVisitation = value; NotifyPropertyChanged(); } }

        public ICommand AddToVisitationCommand { get { return addToVisitationCommand; } set { addToVisitationCommand = value; NotifyPropertyChanged(); } }

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


        #region Show Recommended Visitations Code

        public void ShowPatientRecommendedVisitation()
        {
            RecommendedVisiations = service.GetRecommendedVisitationForPatient(Utill.GetAge(LoggedInPatient.GetPatient().BirhtDate));
        }

        public void AddToMyVisitations(Object obj) {

            MoveToVisitationView moveWindow = new MoveToVisitationView();
            moveWindow.ShowDialog();
            bool isAdded = false;

            ScheduledVisitation visitation = MediatorClass.SelectedVisitation;
            if (visitation != null)
            {
                visitation.Patient = LoggedInPatient.GetPatient();
                visitation.Reason = SelectedVisitation.Reason;
                visitation.Description = selectedVisitation.Description;
                isAdded = visitationService.AddNewScheduleVisitation(visitation);
            }

            if (isAdded)
            {
                new SheduledVisitationsViewModel();
                MessageBox.Show("Added Seccessfuly");
            }
            else
            {
                MessageBox.Show("Error while trying to add visitation");
            }
        }

        #endregion
    }
}
