using NInjectConfigProject;
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Care.DesktopApp.Utills;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using Hospital.Models;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class AskDiagnoseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ScheduledVisitation visitation;
        private string diagnose;
        private ICommand okCommand;

        public AskDiagnoseViewModel(ScheduledVisitation visit)
        {
            okCommand = new RelayCommand(MoveToHistory);
            MediatorClass.OKCommand = okCommand;
            visitation = visit;
        }

        public ICommand OKCommand { get { return okCommand; } set { okCommand = value; NotifyPropertyChanged(); } }

        public string Diagnose { get { return diagnose; } set { diagnose = value; NotifyPropertyChanged(); } }

        public ScheduledVisitation Visitation { get { return visitation; } set { visitation = value; NotifyPropertyChanged(); } }


        private void MoveToHistory(object obj)
        {
            if (!string.IsNullOrEmpty(Diagnose) && !string.IsNullOrWhiteSpace(Diagnose))
            {
                Diagnose = Diagnose;
                string message;

                Boolean isAdded = NinjectConfig.Container.Get<IVisitationService>().MakeVisitationHistory(Visitation.Id, Diagnose);

                if (isAdded)
                {
                    MediatorClass.UpdatePatientVisitations();
                    MediatorClass.UpdatePatientHistory();

                    SheduledVisitationsViewModel.GetInstance().update();
                    HistoryViewModel.GetInstance().update();
                    message = "Moved Successfully";
                }
                else
                {
                    message = "Error while trying to moved the selected visitation";
                }

                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Result", message);
                }));
            }

        }

        #region INotifyPropertyChanged
        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
        #endregion
    }
}
