using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Personal.Health.Care.DesktopApp.Pages.UserManagement;
using NInjectConfigProject;
using Personal.Health.Care.DesktopApp.Utills;

namespace Personal.Health.Care.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += Application_DispatcherUnhandledException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NinjectConfig.ConfigureContainer();
            LoginView login = new LoginView();
            login.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Messenger.ShowMessage(e.Exception.Message);
            e.Handled = true;
        }
    }
}
