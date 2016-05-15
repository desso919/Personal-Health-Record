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
using FluentDateTime;
using Personal.Health.Care.DesktopApp.Model;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class SheduledVisitationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static SheduledVisitationsViewModel instance;
        List<ScheduledVisitation> visitations;
        private IVisitationService service;
        private IHistoryService historyService;
        private ScheduledVisitation selectedVisitation;
        private ICommand moveToHistoryCommand;
        private ICommand editVisitationCommand;
        private string diagnose;

        #region Constructor

        private SheduledVisitationsViewModel()
        {
            service = NinjectConfig.Container.Get<IVisitationService>();
            historyService = NinjectConfig.Container.Get<IHistoryService>();
            moveToHistoryCommand = new RelayCommand(MoveToHistoryMethod);
            editVisitationCommand = new RelayCommand(EditVisitation);
            ShowScheduledVisitations();
        }

        public static SheduledVisitationsViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new SheduledVisitationsViewModel();
            }
            return instance;
        }

        #endregion

        #region Properties

        public List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; NotifyPropertyChanged(); } }

        public ICommand MoveToHistoryCommand { get { return moveToHistoryCommand; } set { moveToHistoryCommand = value; NotifyPropertyChanged(); } }

        public ICommand EditVisitationCommand { get { return editVisitationCommand; } set { editVisitationCommand = value; NotifyPropertyChanged(); } }

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
                SheduledVisitationsViewModel.GetInstance().ShowScheduledVisitations(); 
                MessageBox.Show("  Moved Successfully! ");                
            }
            else
            {
                MessageBox.Show(" Error while trying to moved the selected visitation! ");
            }
        }

        private void EditVisitation(object obj)
        {
            //EditVisitationView edit = new EditVisitationView();
            //edit.ShowDialog();

            ModernDialog1 edit = new ModernDialog1(SelectedVisitation);
            edit.ShowDialog();

           var a = MediatorClass.SelectedVisitation;
        }

        public void ShowScheduledVisitations()
        {
            Visitations = service.GetAllScheduledVisitationsForThisPatient(LoggedInPatient.GetPatient().Id);
        }

        #endregion




    }
}
