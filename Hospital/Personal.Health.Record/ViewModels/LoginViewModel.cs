using Hospital.Models;
using Personal.Health.Record.Views;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Personal.Health.Record.ViewModels
{
    class LoginViewModel
    {
        private string username;
        private string password;

        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }

        private ICommand loginCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;

        public LoginViewModel()
        {
            loginCommand = new RelayCommand(LoginPatient, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; }
        }
       
        public bool CanExecute
        {
            get  { return this.canExecute; }
            set  { this.canExecute = value; }
        }

        public ICommand ToggleExecuteCommand
        {
            get { return toggleExecuteCommand; }
            set { toggleExecuteCommand = value; }
        }
  

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void LoginPatient(object obj)
        {
            IPatientService patientService = new PatientService();
            Patient patient = patientService.Login(Username, Password);
            if (patient != null)
            {
                LoggedInPatient.Init(patient);
                MessageBox.Show(" Welcome : " + patient.FullName);
            }
            else
            {
                MessageBox.Show(" Wrong Username or password : ");
            }
        }
    }
}
