using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Models
{
    public class VisitationFormModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string hospitalMessage;
        private string doctorMessage;
        private string reasonMessage;
        private string diagnoseMessage;
        private string dateMessage;

        #region INotifyPropertyChanged

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

        #endregion

        public string HospitalMessage
        {
            get { return hospitalMessage; }
            set { hospitalMessage = value; NotifyPropertyChanged(); }
        }

        public string DoctorMessage
        {
            get { return doctorMessage; }
            set { doctorMessage = value; NotifyPropertyChanged(); }
        }

        public string ReasonMessage
        {
            get { return reasonMessage; }
            set { reasonMessage = value; NotifyPropertyChanged(); }
        }

        public string DiagnoseMessage
        {
            get { return diagnoseMessage; }
            set { diagnoseMessage = value; NotifyPropertyChanged(); }
        }

        public string DateMessage
        {
            get { return dateMessage; }
            set { dateMessage = value; NotifyPropertyChanged(); }
        }

        public void clearFormMessages()
        {
            HospitalMessage = String.Empty;
            DoctorMessage = String.Empty;
            ReasonMessage = String.Empty;
            DiagnoseMessage = String.Empty;
            DateMessage = String.Empty;
        }  
    }
}
