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
        private Boolean hasSelectedTemplate;
        private string diagnose;

        #region Constructor

        private SheduledVisitationsViewModel()
        {
            service = NinjectConfig.Container.Get<IVisitationService>();
            historyService = NinjectConfig.Container.Get<IHistoryService>();
            moveToHistoryCommand = new RelayCommand(showDiagnoseDialog);
            editVisitationCommand = new RelayCommand(EditVisitation);
   
            Init();
            update();
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

        public ScheduledVisitation SelectedVisitation { get { return selectedVisitation; } set { HasSelectedVisitation = true; selectedVisitation = value; NotifyPropertyChanged(); } }

        public Boolean HasSelectedVisitation { get { return hasSelectedTemplate; } set { hasSelectedTemplate = value; NotifyPropertyChanged(); } }

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

        public void showDiagnoseDialog(object obj)
        {
            AskDiagnoseView dialog = new AskDiagnoseView(SelectedVisitation);
            dialog.ShowDialog();          
        }

        private void EditVisitation(object obj)
        {
            ModernDialog1 edit = new ModernDialog1(SelectedVisitation);
            edit.ShowDialog();
        }

        public void Init()
        {
            MediatorClass.UpdatePatientVisitations();
        }

        public void update()
        {
            Visitations = MediatorClass.Visitations;
        }

        #endregion




    }
}
