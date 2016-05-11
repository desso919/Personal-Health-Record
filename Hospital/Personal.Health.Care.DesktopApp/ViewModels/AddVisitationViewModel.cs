using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Care.DesktopApp.Utills;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class AddVisitationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand addVisitationCommand;
        private IVisitationService service;
        private List<HospitalModel> hospitals;
        private List<Doctor> doctors;
        private ScheduledVisitation visitation;
        private string image;

        public AddVisitationViewModel()
        {
            visitation = new ScheduledVisitation();
            service = NinjectConfig.Container.Get<IVisitationService>();
            Hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
            Doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors();
            addVisitationCommand = new RelayCommand(AddVisitation);
            image = "../../Images/Icons/doctor.png";
        }

        #region Properties

        public string Image
        {
            get { return image; }
            set { image = value; NotifyPropertyChanged(); } 
        }
        public ScheduledVisitation Visitation 
        { 
            get { return visitation; } 
            set { visitation = value; NotifyPropertyChanged(); } 
        }

        public List<HospitalModel> Hospitals
        {
            get { return hospitals; }
            set { hospitals = value; NotifyPropertyChanged(); }
        }

        public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; NotifyPropertyChanged(); }
        }

        public ICommand AddVisitationCommand
        {
            get { return addVisitationCommand; }
            set { addVisitationCommand = value; }
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

        #region Add Visitation Code

        public void AddVisitation(Object obj)
        {

            Visitation.Patient = LoggedInPatient.GetPatient();
            Boolean isAdded = service.AddNewScheduleVisitation(Visitation);

            if (isAdded)
            {
                new SheduledVisitationsViewModel();
                MessageBox.Show(" Scheduled visitation Successfully! ");
            }
            else
            {
                MessageBox.Show(" Error while trying to add Scheduled visitation! ");
            }

            Visitation = new ScheduledVisitation();
        }

        #endregion
    }
}
