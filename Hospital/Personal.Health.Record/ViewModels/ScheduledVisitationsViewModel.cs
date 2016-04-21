using Hospital.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal.Health.Record.ViewModels
{
    class ScheduledVisitationsViewModel : INotifyPropertyChanged
    {
          private List<ScheduledVisitation> visitations;

          public ScheduledVisitationsViewModel()
        {
            showVisitationsCommand = new RelayCommand(ShowVisitations, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        #region Properties 
          public List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; OnPropertyChanged("Visitations"); } }
        #endregion

        #region ICommand
         private ICommand showVisitationsCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;

        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            {
                return toggleExecuteCommand;
            }
            set
            {
                toggleExecuteCommand = value;
            }
        }

        public ICommand ShowVisitationsCommand
        {
            get
            {
                return showVisitationsCommand;
            }
            set
            {
                showVisitationsCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void ShowVisitations(object obj)
        {
            IVisitationService visitationService = new VisitationService();
            Visitations = visitationService.getAllScheduledVisitation();
        } 
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
