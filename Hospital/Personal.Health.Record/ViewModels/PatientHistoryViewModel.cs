﻿using Hospital.Models;
using Personal.Health.Record.Ninject;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;

namespace Personal.Health.Record.ViewModels
{
    class PatientHistoryViewModel : INotifyPropertyChanged
    {
        private IHistoryService service;
        private List<History> histories;

         public PatientHistoryViewModel()
        {
            service = NinjectConfig.Container.Get<IHistoryService>();
            showHistoriesCommand = new RelayCommand(ShowHistories, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        #region Properties 
         public List<History> Histories { get { return histories; } set { histories = value; OnPropertyChanged("Histories"); } }
        #endregion

        #region ICommand
         private ICommand showHistoriesCommand;
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

        public ICommand ShowHistoriesCommand
        {
            get
            {
                return showHistoriesCommand;
            }
            set
            {
                showHistoriesCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void ShowHistories(object obj)
        {
            Histories = service.GetAllHistoryForThisPatient(1);
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
