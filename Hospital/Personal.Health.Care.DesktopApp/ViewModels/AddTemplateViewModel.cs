using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Models;
using Personal.Health.Services;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using Personal.Health.Care.DesktopApp.Utills;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class AddTemplateViewModel : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;
        private ICommand addTemplateCommand;
        private ITemplateService service;
        private List<HospitalModel> hospitals;
        private List<Doctor> doctors;
        private Template template;

        public AddTemplateViewModel()
        {
            template = new Template();
            service = NinjectConfig.Container.Get<ITemplateService>();
            Hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
            Doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors();
            addTemplateCommand = new RelayCommand(AddTempalate);
        }

        #region Properties

        public Template Template 
        { 
            get { return template; } 
            set { template = value; NotifyPropertyChanged(); } 
        }

        public List<HospitalModel> Hospitals
        {
            get { return hospitals; }
            set { hospitals = value; NotifyPropertyChanged(); }
        }

        public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; NotifyPropertyChanged(); }
        }

        public ICommand AddTemplateCommand
        {
            get { return addTemplateCommand; }
            set { addTemplateCommand = value; }
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

        #region Add Template Code

        public void AddTempalate(Object obj)
        {

            Template.Patient = LoggedInPatient.GetPatient();
            Boolean isAdded = service.AddTemplate(Template);

            if (isAdded)
            {
                new TemplatesViewModel();
                Messenger.ShowMessage("Add template Successfully!");
            }
            else
            {
               Messenger.ShowMessage("Error", " Error while trying to add template.");
            }

            Template = new Template();
        }

        #endregion
    }
}
