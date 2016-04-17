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
        private PatientDetailsModel patientModel;

        private string firstName;
        private string secondName;
        private string lastName;
        private string gender;
        private string egn;
        private int age;
        private DateTime birthDate;

        public PatientViewModel()
        {
            showPatientCommand = new RelayCommand(showPatient);
            patientModel = new PatientDetailsModel();
        }

        #region View Properties
        public string FirstName { get { return firstName; } set { firstName = value; OnPropertyChanged("FirstName"); } }
        public string SecondName { get { return secondName; } set { secondName = value; OnPropertyChanged("SecondName"); } }
        public string LastName { get { return lastName; } set { lastName = value; OnPropertyChanged("LastName"); } }
        public string Gender { get { return gender; } set { gender = value; OnPropertyChanged("Gender"); } }
        public string EGN { get { return egn; } set { egn = value; OnPropertyChanged("EGN"); } }
        public long Age { get { return age; } set { age = (int)value; OnPropertyChanged("Age"); } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; OnPropertyChanged("BirthDate"); } }
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
            Patient patient = patientModel.getPatient(id);
            FirstName = patient.FirstName;
            SecondName = patient.SecondName;
            LastName = patient.LastName;
            Age = patient.Age;
            BirthDate = Convert.ToDateTime(patient.BirhtDate);
        }
        #endregion
    }
}
