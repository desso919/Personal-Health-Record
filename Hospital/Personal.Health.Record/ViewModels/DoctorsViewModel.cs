﻿using Hospital.Models;
using Personal.Health.Record.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal.Health.Record.ViewModels
{
    public class DoctorsViewModel : INotifyPropertyChanged
    {
        private DoctorsModel doctorsModel;
        private List<Doctor> doctors;

        public DoctorsViewModel()
        {
            showDoctorsCommand = new RelayCommand(ShowDoctors, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            doctorsModel = new DoctorsModel();
        }

        #region Properties 
        public List<Doctor> Doctors { get { return doctors; } set { doctors = value; OnPropertyChanged("Doctors"); } }
        #endregion

        #region ICommand
        private ICommand showDoctorsCommand;
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

        public ICommand ShowDoctorsCommand
        {
            get
            {
                return showDoctorsCommand;
            }
            set
            {
                showDoctorsCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void ShowDoctors(object obj)
        {

            Doctors = doctorsModel.getDoctors();
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
