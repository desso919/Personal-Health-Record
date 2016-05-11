using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<History> histories;
        private IHistoryService service;

        #region Constructor

        public HistoryViewModel()
        {
            service = NinjectConfig.Container.Get<IHistoryService>();
            ShowPatientHistory();
        }
        #endregion

        #region Properties

        public List<History> Histories { get { return histories; } set { histories = value; NotifyPropertyChanged(); } }

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

        public void ShowPatientHistory()
        {
            Histories = service.GetAllHistoryForThisPatient(LoggedInPatient.GetPatient().Id);
        }

    }
}
