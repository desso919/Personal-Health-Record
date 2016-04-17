using Hospital.Models;
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

        public void LoginPatient(object id)
        {
            IPatientService historyService = new PatientService();
            Patient patient = historyService.getPatient(Convert.ToInt64(id));
            MessageBox.Show("Patietn : " + patient.FullName);
        }
    }
}
