using Hospital.Models;
using Personal.Health.Record.Models;
using Personal.Health.Record.Ninject;
using Personal.Health.Record.Views;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using global::Ninject;

namespace Personal.Health.Record.ViewModels
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand viewProfileCommand;
        private ICommand viewHospitalsCommand;
        private ICommand viewDoctorsCommand;
        private ICommand viewHistoryCommand;
        private ICommand viewSchediledVisitationsCommand;
        List<ScheduledVisitation> visitations;
        private IVisitationService service;

        #region Properties
        public List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; NotifyPropertyChanged(); } }
        #endregion

        public NavigationViewModel()
        {
            service = NinjectConfig.Container.Get<IVisitationService>();
            viewProfileCommand = new RelayCommand(ViewProfile);
            viewHospitalsCommand = new RelayCommand(ViewHospitals);
            viewDoctorsCommand = new RelayCommand(ViewDoctors);
            viewHistoryCommand = new RelayCommand(ViewHistory);
            viewSchediledVisitationsCommand = new RelayCommand(ViewSchediledVisitations);
            ShowScheduledVisitations();
        }

        #region INotifyPropertyChanged
        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
        #endregion

        public void ShowScheduledVisitations()
        {
            Visitations = service.GetAllScheduledVisitationsForThisPatient(2);
        }

        #region Navigation Buttons
        public ICommand ViewProfileCommand
        {
            get { return viewProfileCommand; }
            set { viewProfileCommand = value; }
        }

        public ICommand ViewHospitalsCommand
        {
            get { return viewHospitalsCommand; }
            set { viewHospitalsCommand = value; }
        }

        public ICommand ViewHistoryCommand
        {
            get { return viewHistoryCommand; }
            set { viewHistoryCommand = value; }
        }

        public ICommand ViewSchediledVisitationsCommand
        {
            get { return viewSchediledVisitationsCommand; }
            set { viewSchediledVisitationsCommand = value; }
        }

        public void ViewProfile(object id)
        {
            
        }

        public void ViewHospitals(object id)
        {
            IHospitalService hospitalService = new HospitalService();

        }

        public void ViewDoctors(object id)
        {
            IDoctorService doctorService = new DoctorService();
        }

        public void ViewHistory(object id)
        {
            IHistoryService history = new HistoryService();
        }

        public void ViewSchediledVisitations(object id)
        {
            IVisitationService SchediledVisitations = new VisitationService();
        }
        #endregion

     
    }
}
