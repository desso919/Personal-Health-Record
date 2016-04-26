using Hospital.Models;
using Personal.Health.Record.Models;
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
    public class PatientViewModel : INotifyPropertyChanged
    {
        private Patient logedInPatient;

        public PatientViewModel()
        {
            showPatientCommand = new RelayCommand(showPatient);
        }

        #region View Properties
        public Patient LogedInPatient { get { return logedInPatient; } set { logedInPatient = value; OnPropertyChanged("LogedInPatient"); } }

        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #region ICommand  
        private ICommand showPatientCommand;

        public ICommand ShowPatientCommand
        {
            get { return showPatientCommand; }
            set { showPatientCommand = value; }
        }

        private void showPatient(object id)
        {
            IPatientService patientService = new PatientService();
            LogedInPatient =  patientService.GetPatient(1);
        }
        #endregion
    }
}
