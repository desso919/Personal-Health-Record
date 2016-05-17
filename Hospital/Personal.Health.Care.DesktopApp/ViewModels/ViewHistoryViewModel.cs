using Hospital.Models;
using Personal.Health.Care.DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class ViewHistoryViewModel
    {
        private History history;

        public ViewHistoryViewModel(History history)
        {
            if(history != null) {

                history.Doctor = MediatorClass.Doctors.Find(doctor => doctor.DoctorId == history.DoctorId);
                history.Hospital = MediatorClass.Hospitals.Find(hospital => hospital.HospitalId == history.HospitalId);
                History = history;
            }
        }

        public History History { get { return history; } set { history = value; } }
    }
}
