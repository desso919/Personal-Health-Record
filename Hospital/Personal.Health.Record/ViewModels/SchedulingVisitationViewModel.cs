using Hospital.Models;
using Personal.Health.Record.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Personal.Health.Record.ViewModels
{
    class SchedulingVisitationViewModel
    {
        private SchedulingVisitationModul schedulingVisitationModul;

        private long hospitalId;
        private long doctorId;
        private DateTime date;
        private string reason;
        private string description;

        public SchedulingVisitationViewModel()
        {
            addNewScheduledVisitationCommand = new RelayCommand(ScheduleNewVisitation, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            schedulingVisitationModul = new SchedulingVisitationModul();
        }

        #region Properties 
        public long HospitalId { get { return hospitalId; } set { hospitalId = value; } }
        public long DoctorId { get { return doctorId; } set { doctorId = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string Reason { get { return reason; } set { reason = value; } }
        public string Description { get { return description; } set { description = value; } }
        #endregion

        #region ICommand
        private ICommand addNewScheduledVisitationCommand;
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

        public ICommand AddNewScheduledVisitationCommand
        {
            get
            {
                return addNewScheduledVisitationCommand;
            }
            set
            {
                addNewScheduledVisitationCommand = value;
            }
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void ScheduleNewVisitation(object obj)
        {
            ScheduledVisitation visitation = new ScheduledVisitation();
            visitation.HospitalId = HospitalId;
            visitation.DoctorId = DoctorId;
            visitation.Reason = Reason;
            visitation.Date = Date;
            visitation.Description = Description;
            Boolean isAdded = schedulingVisitationModul.AddNewScheduleVisitation(visitation);

            if (isAdded)
            {
                MessageBox.Show(" Scheduled new visitation successfully! ");
            }
            else
            {
                MessageBox.Show(" Error while trying to schedule new visitation! ");
            }
        }
        #endregion
    }
}
