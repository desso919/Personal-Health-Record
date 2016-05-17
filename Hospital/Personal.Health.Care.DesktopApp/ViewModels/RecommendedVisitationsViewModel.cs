using NInjectConfigProject;
using Personal.Health.Models;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Runtime.CompilerServices;
using Personal.Health.Care.DesktopApp.Utills;
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Pages.Views;
using Hospital.Models;
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Services;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class RecommendedVisitationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<RecommendedVisitation> visiations;
        private IRecommendedVisitationService service;
        private IVisitationService visitationService;
        private RecommendedVisitation selectedVisitation;
        private ICommand addToVisitationCommand;
        private Boolean isSelected;

        #region Constructor

        public RecommendedVisitationsViewModel()
        {
            service = NinjectConfig.Container.Get<IRecommendedVisitationService>();
            visitationService = NinjectConfig.Container.Get<IVisitationService>();
            addToVisitationCommand = new RelayCommand(AddToMyVisitations);
            update();
        }
        #endregion

        #region Properties

        public List<RecommendedVisitation> RecommendedVisiations { get { return visiations; } set { visiations = value; NotifyPropertyChanged(); } }

        public RecommendedVisitation SelectedVisitation { get { return selectedVisitation; } set { HasSelectedVisitation = true; selectedVisitation = value; NotifyPropertyChanged(); } }

        public ICommand AddToVisitationCommand { get { return addToVisitationCommand; } set { addToVisitationCommand = value; NotifyPropertyChanged(); } }

        public Boolean HasSelectedVisitation { get { return isSelected; } set { isSelected = value; NotifyPropertyChanged(); } }

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


        #region Show Recommended Visitations Code

        public void update()
        {
            RecommendedVisiations = MediatorClass.RecommendedVisitation;
        }

        public void AddToMyVisitations(Object obj) {

            MoveToVisitationView moveWindow = new MoveToVisitationView(SelectedVisitation);
            moveWindow.ShowDialog();         
        }

        #endregion
    }
}
