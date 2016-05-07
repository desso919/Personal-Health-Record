using Hospital.Models;
using Personal.Health.Record.Ninject;
using Personal.Health.Record.Utilities;
using Personal.Health.Record.Views;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ninject;

namespace Personal.Health.Record.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IPatientService service;
        private ICommand loginCommand;
        private string loginCredential;
        private SecureString password;

        #region Constructor

        public LoginViewModel()
        {
            service = NinjectConfig.Container.Get<IPatientService>();
            loginCommand = new RelayCommand(LoginPatient);
        }

        #endregion

        #region Class Properties

        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; }
        }

        public string LoginCredential 
        { 
            get { return loginCredential; } 
            set { loginCredential = value; NotifyPropertyChanged(); } 
        }

        public SecureString Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
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

        #region Login Patient code

        public void LoginPatient(object obj)
        {
            Patient patient = null;

            if (LoginCredential == null || Password == null)
            {
                MessageBox.Show(" Please enter username and password first!");
            }

            if (isEGN(LoginCredential))
            {
                patient = service.LoginWithEGN(LoginCredential, SecurityUtil.ConvertToString(Password));
            }
            else
            {
                patient = service.LoginWithUsername(LoginCredential, SecurityUtil.ConvertToString(Password));
            }
            
            if (patient != null)
            {
                LoggedInPatient.Init(patient);
                MessageBox.Show(" Welcome : " + patient.FullName);
            }
            else
            {
                MessageBox.Show(" Wrong Username or password. Please try again!");
            }
        }

        private bool isEGN(string loginCredential)
        {
            string regExPattern = @"^[0-9]+$";
            Regex pattern = new Regex(regExPattern);
            return pattern.IsMatch(loginCredential);
        }

        #endregion
    }
}
