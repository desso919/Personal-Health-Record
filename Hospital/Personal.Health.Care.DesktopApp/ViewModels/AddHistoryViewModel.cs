using NInjectConfigProject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using Personal.Health.Care.DesktopApp.Utills;
using System.ComponentModel;
using System.Windows;
using Hospital.Models;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Controls;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class AddHistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand addHistoryCommand;
        private IHistoryService service;
        private List<HospitalModel> hospitals;
        private List<Doctor> doctors;
        private History history;
        private string image;

        public AddHistoryViewModel()
        {
            history = new History();
            service = NinjectConfig.Container.Get<IHistoryService>();
            Hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
            Doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors();
            addHistoryCommand = new RelayCommand(AddHistoryRecord);
            image = "../../Images/Icons/doctor.png";
        }

        #region Properties

        public string Image
        {
            get { return image; }
            set { image = value; NotifyPropertyChanged(); } 
        }
        public History History 
        { 
            get { return history; } 
            set { history = value; NotifyPropertyChanged(); } 
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

        public ICommand AddHistoryCommand
        {
            get { return addHistoryCommand; }
            set { addHistoryCommand = value; }
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

        #region Add History Code

        public void AddHistoryRecord(object obj)
        {

            History.Patient = LoggedInPatient.GetPatient();
            Boolean isAdded = service.addHistory(History);

            if (isAdded)
            {
                new HistoryViewModel();
                MessageBox.Show(" History Added Successfully! ");
            }
            else
            {
                MessageBox.Show(" Error while trying to add history! ");
            }
            History = new History();
        }

        #endregion
    }
}
