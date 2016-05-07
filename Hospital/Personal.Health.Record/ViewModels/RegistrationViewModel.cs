using Personal.Health.Record.Ninject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using System.Runtime.CompilerServices;

namespace Personal.Health.Record.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand registerCommand;
        private IPatientService service;

        #region Constructor

        public RegistrationViewModel()
        {
            service = NinjectConfig.Container.Get<IPatientService>();
            registerCommand = new RelayCommand(RegisterPatient);
        }

        #endregion

        #region Class Properties

        public ICommand RegisterCommand
        {
            get { return registerCommand; }
            set { registerCommand = value; }
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

        public void RegisterPatient(Object obj)
        {

        }
      
    }
}
