﻿using Hospital.Models;
using NInjectConfigProject;
using Personal.Health.Care.DesktopApp.Utills;
using Personal.Health.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using System.Runtime.CompilerServices;
using System.Windows;
using Personal.Health.Care.DesktopApp.Pages.Views;
using Personal.Health.Models;
using Personal.Health.Care.DesktopApp.Model;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class AddVisitationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand addVisitationCommand;
        private ICommand loadTemplateCommand;
        private IVisitationService service;
        private List<HospitalModel> hospitals;
        private List<Doctor> doctors;
        private ScheduledVisitation visitation;

        public AddVisitationViewModel()
        {
            visitation = new ScheduledVisitation();
            service = NinjectConfig.Container.Get<IVisitationService>();
            Hospitals = NinjectConfig.Container.Get<IHospitalService>().GetAllHispitals();
            Doctors = NinjectConfig.Container.Get<IDoctorService>().GetAllDoctors();
            addVisitationCommand = new RelayCommand(AddVisitation);
            loadTemplateCommand = new RelayCommand(LoadTemplateMethod);
        }

        #region Properties

        public ScheduledVisitation Visitation
        {
            get { return visitation; }
            set { visitation = value; NotifyPropertyChanged(); }
        }

        public HospitalModel Hospital
        {
            get { return MediatorClass.SelectedVisitation.Hospital; }
            set { MediatorClass.SelectedVisitation.Hospital = value; NotifyPropertyChanged(); }
        }
        public Doctor Doctor
        {
            get { return MediatorClass.SelectedVisitation.Doctor; }
            set { MediatorClass.SelectedVisitation.Doctor = value; NotifyPropertyChanged(); }
        }
        public string VisitationDate
        {
            get { return MediatorClass.SelectedVisitation.Date; }
            set { MediatorClass.SelectedVisitation.Date = value; NotifyPropertyChanged(); }
        }


        public List<HospitalModel> Hospitals
        {
            get { return hospitals; }
            set { hospitals = value; NotifyPropertyChanged(); }
        }

        public ICommand LoadTemplateCommand { get { return loadTemplateCommand; } set { loadTemplateCommand = value; NotifyPropertyChanged(); } }

        public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; NotifyPropertyChanged(); }
        }

        public ICommand AddVisitationCommand
        {
            get { return addVisitationCommand; }
            set { addVisitationCommand = value; }
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

        #region Add Visitation Code

        public void AddVisitation(Object obj)
        {

            Visitation.Patient = LoggedInPatient.GetPatient();
            Boolean isAdded = service.AddNewScheduleVisitation(Visitation);

            if (isAdded)
            {
                new SheduledVisitationsViewModel();
                MessageBox.Show(" Scheduled visitation Successfully! ");
            }
            else
            {
                MessageBox.Show(" Error while trying to add Scheduled visitation! ");
            }

            Visitation = new ScheduledVisitation();
        }

        public void LoadTemplateMethod(Object obj)
        {
            SelectTemplateView selectTemplateWindow = new SelectTemplateView();
            selectTemplateWindow.ShowDialog();

            Template selectedTemplate = MediatorClass.SelectedTemplate;

            if (selectedTemplate != null)
            {
                ScheduledVisitation loadFromTemplate = new ScheduledVisitation();

                loadFromTemplate.Hospital = Hospitals.FirstOrDefault(h => h.HospitalId == selectedTemplate.HospitalId);
                loadFromTemplate.Doctor = Doctors.FirstOrDefault(h => h.DoctorId == selectedTemplate.DoctorId); ;
                loadFromTemplate.Reason = selectedTemplate.Reason;
                loadFromTemplate.Description = selectedTemplate.Description;
                Visitation = loadFromTemplate;
            }
        }

        #endregion
    }
}
