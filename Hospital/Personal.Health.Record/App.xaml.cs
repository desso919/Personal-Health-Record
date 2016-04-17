using Personal.Health.Record.Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Personal.Health.Record
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NinjectConfig.ConfigureContainer();
            NinjectConfig.ComposeObjects(Current);
            Current.MainWindow.Show();
        }
    }
}
