using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string patientName;

        public HomeViewModel()
        {
            PatientName = LoggedInPatient.GetPatient().FullName;
        }

        public string PatientName { get { return patientName; } set { patientName = value; NotifyPropertyChanged(); } }

        #region INotifyPropertyChanged

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

        #endregion

       
    }
}
