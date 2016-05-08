using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class SheduledVisitationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<ScheduledVisitation> visitations;
        private IVisitationService service;

        #region Constructor

        public SheduledVisitationsViewModel()
        {
            service = NinjectConfig.Container.Get<IVisitationService>();
            ShowScheduledVisitations();
        }
        #endregion

        #region Properties
        public List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; NotifyPropertyChanged(); } }
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

        public void ShowScheduledVisitations()
        {
            Visitations = service.GetAllScheduledVisitationsForThisPatient(LoggedInPatient.GetPatient().Id);
        }

       
    }
}
