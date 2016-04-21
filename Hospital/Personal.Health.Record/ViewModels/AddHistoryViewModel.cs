using Hospital.Models;
using Personal.Health.Record.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Personal.Health.Record.ViewModels
{
    class AddHistoryViewModel : INotifyPropertyChanged
    {
        private AddHistoryModel historyModel;

        private long hospitalId;
        private long doctorId;
        private DateTime date;
        private string reason;
        private string diagnose;
        private string description;

        public AddHistoryViewModel()
        {
            addHistoryCommand = new RelayCommand(AddHistoryRecord, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            historyModel = new AddHistoryModel();
        }

        #region Properties 
        public long HospitalId { get { return hospitalId; } set { hospitalId = value; } }
        public long DoctorId { get { return doctorId; } set { doctorId = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string Reason { get { return reason; } set { reason = value; } }
        public string Diagnose { get { return diagnose; } set { diagnose = value; } }
        public string Description { get { return description; } set { description = value; } }
        #endregion
        #region ICommand
        private ICommand addHistoryCommand;
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

        public ICommand AddHistoryCommand
        {
            get
            {
                return addHistoryCommand;
            }
            set
            {
                addHistoryCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void AddHistoryRecord(object obj)
        {
            History history = new History();
            history.HospitalId = HospitalId;
            history.DoctorId = DoctorId;
            history.Reason = Reason;
            history.Diagnose = Diagnose;
            history.Date = Date;
            history.Description = Description;
            Boolean isAdded =  historyModel.addHistory(history);

            if (isAdded)
            {
                MessageBox.Show(" History Added Successfully! ");
            }
            else
            {
                MessageBox.Show(" Error while trying to add history! ");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
