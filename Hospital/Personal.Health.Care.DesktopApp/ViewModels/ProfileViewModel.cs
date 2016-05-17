using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Utills;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Personal.Health.Care.DesktopApp.Pages.Views;
using Personal.Health.Care.DesktopApp.Pages.UserManagement;
using System.Windows;
using Personal.Health.Care.DesktopApp.Model;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand logoutCommand;

        public ProfileViewModel()
        {
            logoutCommand = new RelayCommand(logOut);
        }

        #region Properties

        public ICommand LogoutCommand
        {
            get { return logoutCommand; }
            set { logoutCommand = value; }
        }

        public Patient Patient { get { return LoggedInPatient.GetPatient(); } }

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

        #region Logout code 

        public void logOut(Object obj)
        {
            ExitConfirmView confirm = new ExitConfirmView();
            confirm.ShowDialog();

            var mainWindows = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            if (mainWindows != null)
            {
                LoggedInPatient.LogoutPatient();
                MediatorClass.Hospitals = null;
                MediatorClass.Doctors = null;
                MediatorClass.Histories = null;
                MediatorClass.Visitations = null;
                MediatorClass.RecommendedVisitation = null;
                MediatorClass.Templates = null;
                LoginView loginPage = new LoginView();
                loginPage.Show();                   
                mainWindows.Close();
            }
            else
            {
                MessageBox.Show(" Something went wrong! ");
            }   
        }

        #endregion
    }
}
