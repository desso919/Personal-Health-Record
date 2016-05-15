using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Runtime.CompilerServices;
using Personal.Health.Care.DesktopApp.Model;
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Utills;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class EditVisitationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ScheduledVisitation visitation;
        private List<HospitalModel> hospitals;
        private ICommand saveCommand;
        private List<Doctor> doctors;

        #region Constructor

        public EditVisitationViewModel(ScheduledVisitation visitation)
        {
            Hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
            Doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors().Result;
            saveCommand = new RelayCommand(SaveVisitation);
            MediatorClass.SaveCommand = SaveCommand;
            LoadVisitation(visitation);
        }

        #endregion

        #region Properties

        public ScheduledVisitation Visitation { get { return visitation; } set { visitation = value; NotifyPropertyChanged(); } }

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

        public ICommand SaveCommand { get { return saveCommand; } set { saveCommand = value; NotifyPropertyChanged(); } }

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

        #region Show Visitation for editing

        private void LoadVisitation(ScheduledVisitation visitation)
        {
            Visitation = visitation.Clone();
            Visitation.Doctor = Doctors.Find(doctor => doctor.DoctorId == visitation.DoctorId);
            Visitation.Hospital = Hospitals.Find(hospital => hospital.HospitalId == visitation.HospitalId);
        }

        private void SaveVisitation(object obj)
        {
            bool isSuccessfullyEdited = NinjectConfig.Container.Get<IVisitationService>().EditVisitation(Visitation);

            if (isSuccessfullyEdited)
            {
                SheduledVisitationsViewModel.GetInstance().ShowScheduledVisitations();
                MessageBox.Show("Result", "Visitation Successfully Edited");
            }
            else
            {
                MessageBox.Show("Error", "Error whule trying to save your changes");
            }
        }

        #endregion
    }
}
