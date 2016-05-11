using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Models
{
    public class RegistrationFormModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string usernameMessage;
        private string firstNameMessage;
        private string secondNameMessage;
        private string lastNameMessage;
        private string egnMessage;
        private string birthDateMessage;

        #region INotifyPropertyChanged

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

        #endregion

        public string UsernameMessage
        {
            get { return usernameMessage; }
            set { usernameMessage = value; NotifyPropertyChanged(); }
        }

        public string FirstNameMessage
        {
            get { return firstNameMessage; }
            set { firstNameMessage = value; NotifyPropertyChanged(); }
        }

        public string SecondNameMessage
        {
            get { return secondNameMessage; }
            set { secondNameMessage = value; NotifyPropertyChanged(); }
        }

        public string LastNameMessage
        {
            get { return lastNameMessage; }
            set { lastNameMessage = value; NotifyPropertyChanged(); }
        }

        public string EGNMessage
        {
            get { return egnMessage; }
            set { egnMessage = value; NotifyPropertyChanged(); }
        }

        public string BirthDateMessage
        {
            get { return birthDateMessage; }
            set { birthDateMessage = value; NotifyPropertyChanged(); }
        }

        public void clearFormMessages()
        {
            UsernameMessage = String.Empty;
            FirstNameMessage = String.Empty;
            SecondNameMessage = String.Empty;
            LastNameMessage = String.Empty;
            EGNMessage = String.Empty;
            BirthDateMessage = String.Empty;
        }  
    }
}
