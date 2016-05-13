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

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class TemplatesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<Template> templates;
        private ITemplateService service;
        private Template selectedTemplate;

        #region Constructor

        public TemplatesViewModel()
        {
            service = NinjectConfig.Container.Get<ITemplateService>();
            ShowAllPatientTemplates();
        }
        #endregion

        #region Properties

        public List<Template> Templates { get { return templates; } set { templates = value; NotifyPropertyChanged(); } }

        public Template SelectedTemplate { get { return MediatorClass.SelectedTemplate; } set { MediatorClass.SelectedTemplate = value; NotifyPropertyChanged(); } }


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
            Templates = service.GetAllPatientTemplates(LoggedInPatient.GetPatient().Id);
        }

        #endregion
    }
}
