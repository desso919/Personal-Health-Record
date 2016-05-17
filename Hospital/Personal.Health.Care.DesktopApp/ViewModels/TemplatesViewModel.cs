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
        private Template template;
        private Boolean hasSelectedTemplate;
        private static TemplatesViewModel instance;

        #region Constructor

        private TemplatesViewModel()
        {
             template = new Template();
             service = NinjectConfig.Container.Get<ITemplateService>();
             editTemplateCommand = new RelayCommand(EditTemplate);
             addTemplateCommand = new RelayCommand(AddTempalate);
             Init();
             update();
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

        public List<Template> Templates { get { return templates; } set { templates = value; NotifyPropertyChanged(); } }

        public ICommand EditTemplateCommand { get { return editTemplateCommand; } set { editTemplateCommand = value; NotifyPropertyChanged(); } }

        public Template SelectedTemplate { get { return MediatorClass.SelectedTemplate; } set { HasSelectedVisitation = true; MediatorClass.SelectedTemplate = value; NotifyPropertyChanged(); } }

        public Boolean HasSelectedVisitation { get { return hasSelectedTemplate; } set { hasSelectedTemplate = value; NotifyPropertyChanged(); } }


        public Template Template
        {
            get { return template; }
            set { template = value; NotifyPropertyChanged(); }
        }

        public List<HospitalModel> Hospitals
        {
            get { return MediatorClass.Hospitals; }
        }

        public List<Doctor> Doctors
        {
            get { return MediatorClass.Doctors; }
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

        private void EditTemplate(object obj)
        {
            TemplateEdit edit = new TemplateEdit(SelectedTemplate);
            edit.ShowDialog();
        }

        #endregion

        #region Add Template Code
        public void AddTempalate(Object obj)
        {
            if (Utills.Utill.isValidTemplate(Template))
            {
                Template.Patient = LoggedInPatient.GetPatient();
                Boolean isAdded = service.AddTemplate(Template);
                string message = String.Empty;

                if (isAdded)
                {
                    Template.HospitalId = Template.Hospital.HospitalId;
                    Template.DoctorId = Template.Doctor.DoctorId;
                    Templates.Add(Template);
                    message = "Template Added Successfully";
                }
                else
                {
                    message = " Error while trying to add template";
                }

                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Result", message);
                }));

                Template = new Template();
            }    
        }

        public void Init()
        {
            MediatorClass.UpdatePatientTemplates();
        }

        public void update()
        {
            Templates = MediatorClass.Templates;
        }

        #endregion

       
    }
}
