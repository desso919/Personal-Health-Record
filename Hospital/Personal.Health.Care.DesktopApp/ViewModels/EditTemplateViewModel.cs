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
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Services;
using Hospital.Models;
using System.Windows.Input;
using Personal.Health.Care.DesktopApp.Utills;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
     public class EditTemplateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;                   
        private List<HospitalModel> hospitals;
        private ICommand saveCommand;
        private List<Doctor> doctors;
        private Template template;

        #region Constructor

        public EditTemplateViewModel(Template template)
        {
            saveCommand = new RelayCommand(SaveTemplate);
            MediatorClass.SaveTemplateCommand = SaveTemplateCommand;
            LoadTemplate(template);       
        }

        #endregion

        #region Properties

        public Template Template { get { return template; } set { template = value; NotifyPropertyChanged(); } }

        public List<HospitalModel> Hospitals
        {
            get { return MediatorClass.Hospitals; }
        }

        public List<Doctor> Doctors
        {
            get { return MediatorClass.Doctors; }
        }

        public ICommand SaveTemplateCommand { get { return saveCommand; } set { saveCommand = value; NotifyPropertyChanged(); } }

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

        #region Show Template

        private void LoadTemplate(Template template)
        {
            if (template != null)
            {
                Template = template.Clone();
                Template.Doctor = Doctors.Find(doctor => doctor.DoctorId == template.DoctorId);
                Template.Hospital = Hospitals.Find(hospital => hospital.HospitalId == template.HospitalId);
            }        
        }

        private void SaveTemplate(object obj)
        {
            if (Utills.Utill.isValidTemplate(Template))
            {
                Template.Patient = LoggedInPatient.GetPatient();
                bool isSuccessfullyEdited = NinjectConfig.Container.Get<ITemplateService>().EditTemplate(Template);
                string message = String.Empty;

                if (isSuccessfullyEdited)
                {
                    MediatorClass.UpdatePatientTemplates();
                    TemplatesViewModel.GetInstance().update();
                    message = "Template Successfully Edited";
                }
                else
                {
                    message = "Error while trying to save your changes";
                }

                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Operation Result", message);
                }));
            } 
        }

        #endregion
    }
}
