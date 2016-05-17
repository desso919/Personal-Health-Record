using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Personal.Health.Care.DesktopApp.Model;
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Pages.Views;
using Personal.Health.Care.DesktopApp.Utills;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static HistoryViewModel instance;        
        private List<History> histories;
        private IHistoryService service;
        private ICommand viewHistoryCommand;
        private History selectedHistory;
        private Boolean hasSelectedTemplate;


        #region Constructor

        private HistoryViewModel()
        {
            service = NinjectConfig.Container.Get<IHistoryService>();
            viewHistoryCommand = new RelayCommand(ViewSelectedHistory);
            Init();
            update();
        }

        private void ViewSelectedHistory(object obj)
        {
            ViewHistory viewHistory = new ViewHistory(SelectedHistory);
            viewHistory.ShowDialog();
        }


        public static HistoryViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new HistoryViewModel();
            }
            return instance;
        }
        #endregion

        #region Properties

        public List<History> Histories { get { return histories; } set { histories = value; NotifyPropertyChanged(); } }

        public History SelectedHistory { get { return selectedHistory; } set { HasSelectedVisitation = true; selectedHistory = value; NotifyPropertyChanged(); } }

        public ICommand ViewHistoryCommand { get { return viewHistoryCommand; } set { viewHistoryCommand = value; NotifyPropertyChanged(); }}

        public Boolean HasSelectedVisitation { get { return hasSelectedTemplate; } set { hasSelectedTemplate = value; NotifyPropertyChanged(); } }

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

        public void Init()
        {
            MediatorClass.UpdatePatientHistory();
        }

        public void update()
        {
            Histories = MediatorClass.Histories;
        }
    }
}
