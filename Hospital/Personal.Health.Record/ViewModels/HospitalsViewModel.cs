using Hospital.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal.Health.Record.ViewModels
{
    class HospitalsViewModel : INotifyPropertyChanged
    {
        private List<HospitalModel> hospitals;

        public HospitalsViewModel()
        {
            showHospitalsCommand = new RelayCommand(ShowHospitals, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        #region Properties 
        public List<HospitalModel> Hospitals { get { return hospitals; } set { hospitals = value; OnPropertyChanged("Hospitals"); } }
        #endregion

        #region ICommand
        private ICommand showHospitalsCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;

        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            {
                return toggleExecuteCommand;
            }
            set
            {
                toggleExecuteCommand = value;
            }
        }

        public ICommand ShowHospitalsCommand
        {
            get
            {
                return showHospitalsCommand;
            }
            set
            {
                showHospitalsCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void ShowHospitals(object obj)
        {
            IHospitalService hospitalService = new HospitalService();
            Hospitals = hospitalService.GetAllHispitals();
        } 
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
