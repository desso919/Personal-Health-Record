using NInjectConfigProject;
using Personal.Health.Models;
using Personal.Health.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using System.Runtime.CompilerServices;
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Care.DesktopApp.Utills;
using Personal.Health.Care.DesktopApp.Pages.Views;
using System.Collections.ObjectModel;
using Hospital.Models;
using Personal.Health.Services;
using System.Windows;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class TemplatesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand editTemplateCommand;
        private ICommand addTemplateCommand;
        private ITemplateService service;
        private List<Template> templates;
        private List<HospitalModel> hospitals;
        private List<Doctor> doctors;
        private Template template;
        private static TemplatesViewModel instance;

        #region Constructor

        private TemplatesViewModel()
        {
             template = new Template();
             service = NinjectConfig.Container.Get<ITemplateService>();
             editTemplateCommand = new RelayCommand(EditTemplate);
             //Hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
             //Doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors();
             addTemplateCommand = new RelayCommand(AddTempalate);         
        }

        public static TemplatesViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new TemplatesViewModel();
            }
            return instance;
        }

        #endregion

        #region Properties

        public List<Template> Templates { get { return MediatorClass.Templates; } set { templates = value; NotifyPropertyChanged(); } }

        public ICommand EditTemplateCommand { get { return editTemplateCommand; } set { editTemplateCommand = value; NotifyPropertyChanged(); } }

        public Template SelectedTemplate { get { return MediatorClass.SelectedTemplate; } set { MediatorClass.SelectedTemplate = value; NotifyPropertyChanged(); } }

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


        #region show templates Code

        public void ShowAllPatientTemplates()
        {
            Templates = new List<Template>(service.GetAllPatientTemplates(LoggedInPatient.GetPatient().Id));
        }

        private void EditTemplate(object obj)
        {
            TemplateEdit edit = new TemplateEdit(SelectedTemplate);
            edit.ShowDialog();
        }

        #endregion

        #region Add Template Code
        public void AddTempalate(Object obj)
        {
            Template.Patient = LoggedInPatient.GetPatient();
            Boolean isAdded = service.AddTemplate(Template);

            if (isAdded)
            {
                ShowAllPatientTemplates();
                MessageBox.Show("Add template Successfully!");
            }
            else
            {
                MessageBox.Show("Error", " Error while trying to add template.");
            }

            Template = new Template();
        }

        #endregion
    }
}
