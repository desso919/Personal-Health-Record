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
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Utills;
using System.Windows;
using Personal.Health.Care.DesktopApp.Pages.Views;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class SheduledVisitationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<ScheduledVisitation> visitations;
        private IVisitationService service;
        private IHistoryService historyService;
        private ScheduledVisitation selectedVisitation;
        private ICommand moveToHistoryCommand;
        private string diagnose;

        #region Constructor

        public SheduledVisitationsViewModel()
        {
            service = NinjectConfig.Container.Get<IVisitationService>();
            historyService = NinjectConfig.Container.Get<IHistoryService>();
            moveToHistoryCommand = new RelayCommand(MoveToHistoryMethod);
            ShowScheduledVisitations();
        }
        #endregion

        #region Properties

        public List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; NotifyPropertyChanged(); } }

        public ICommand MoveToHistoryCommand { get { return moveToHistoryCommand; } set { moveToHistoryCommand = value; NotifyPropertyChanged(); } }

        public ScheduledVisitation SelectedVisitation { get { return selectedVisitation; } set { selectedVisitation = value; NotifyPropertyChanged(); } }

        public string Diagnose { get { return diagnose; } set { diagnose = value; NotifyPropertyChanged(); } }
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


        #region Move to history Code

        public void MoveToHistoryMethod(object obj)
        {
            AskDiagnoseView dialog = new AskDiagnoseView();
            dialog.ShowDialog();

            if (dialog.ResponseText == null || dialog.ResponseText.Equals(String.Empty))
            {
                MessageBox.Show(" Cannot move without diagnose! ");
                return;
            }

            Diagnose = dialog.ResponseText;
            Boolean isAdded = service.MakeVisitationHistory(SelectedVisitation.Id, Diagnose);

            if (isAdded)
            {
                ShowScheduledVisitations(); 
                MessageBox.Show("  Moved Successfully! ");                
            }
            else
            {
                MessageBox.Show(" Error while trying to Moved the selected visitation! ");
            }
        }

        public void ShowScheduledVisitations()
        {
            Visitations = service.GetAllScheduledVisitationsForThisPatient(LoggedInPatient.GetPatient().Id);
        }

        #endregion




    }
}
