using NInjectConfigProject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using Personal.Health.Care.DesktopApp.Utills;
using System.ComponentModel;
using System.Windows;
using Hospital.Models;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Controls;
using Personal.Health.Care.DesktopApp.Model;
using System.Threading;
using System.Windows.Threading;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class AddHistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand addHistoryCommand;
        private IHistoryService service;
        private History history;

        public AddHistoryViewModel()
        {
            history = new History();
            service = NinjectConfig.Container.Get<IHistoryService>();
            addHistoryCommand = new RelayCommand(AddHistoryRecord);
        }

        #region Properties

        public History History
        {
            get { return history; }
            set { history = value; NotifyPropertyChanged(); }
        }

        public List<HospitalModel> Hospitals
        {
            get { return MediatorClass.Hospitals; }
        }

        public List<Doctor> Doctors
        {
            get { return MediatorClass.Doctors; }
        }

        public ICommand AddHistoryCommand
        {
            get { return addHistoryCommand; }
            set { addHistoryCommand = value; }
        }

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

        #region Add History Code

        public void AddHistoryRecord(object obj)
        {

            if (Utills.Utill.isValidHistory(History))
            {
                History.Patient = LoggedInPatient.GetPatient();
                Boolean isAdded = service.addHistory(History);
                string message;

                if (isAdded)
                {
                    MediatorClass.UpdatePatientHistory();
                    HistoryViewModel.GetInstance().update();
                    message = "History Added Successfully";
                }
                else
                {
                    message = " Error while trying to add history! ";
                }

                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Result", message);
                }));

                History = new History();  
            }
        }

        #endregion
    }
}
