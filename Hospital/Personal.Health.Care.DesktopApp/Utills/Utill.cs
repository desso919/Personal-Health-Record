using Hospital.Models;
using Personal.Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.Utills
{
    public static class Utill
    {
        public static string usernameMessage = "Please enter a valid username name";
        public static string firstNameMessage = "Please enter a valid first name";
        public static string secondNameMessage =  "Please enter a valid second name"; 
        public static string lastNameMessage = "Please enter a valid last name";
        public static string egnMessage = "Please enter a valid EGN. It Must contain only digits!";
        public static string birthDateMessage = "Please enter a valid birth date!";

        public static int GetAge(string birthday)
        {
            DateTime _birthday = Convert.ToDateTime(birthday);
            DateTime now = DateTime.Today;
            int age = now.Year - _birthday.Year;
            if (now < _birthday.AddYears(age)) age--;

            return age;
        }

        public static string formatDate(string date)
        {
            if (date == null) return null;
            return String.Format("{0:f}", date);
        }

        public static bool isValidTemplate(Template template)
        {
            if (!SecurityUtil.isValidString(template.Title))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("title"));
                }));
                return false;
            }

            if (template.Hospital == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a hospital");
                }));
                return false;
            }

            if (template.Doctor == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a doctor");
                }));
                return false;
            }

            return true;
        }

        public static bool isValidVisitation(ScheduledVisitation visitation)
        {          
            if (visitation.Hospital == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a hospital");
                }));
                return false;
            }

            if (visitation.Doctor == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a doctor");
                }));
                return false;
            }

            if (!SecurityUtil.isValidDate(visitation.Date))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("date"));
                }));
                return false;
            }

            if (!SecurityUtil.isValidString(visitation.Reason))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("reason"));
                }));
                return false;
            }

            return true;
        }

        public static bool isValidRecVisitation(ScheduledVisitation visitation)
        {
            if (visitation.Hospital == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a hospital");
                }));
                return false;
            }

            if (visitation.Doctor == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a doctor");
                }));
                return false;
            }

            if (!SecurityUtil.isValidDate(visitation.Date))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("date"));
                }));
                return false;
            }
            return true;
        }


        public static bool isValidHistory(History history)
        {
            if (history.Hospital == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a hospital");
                }));
                return false;
            }

            if (history.Doctor == null)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage("Please select a doctor");
                }));
                return false;
            }

            if (!SecurityUtil.isValidDate(history.Date))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("date"));
                }));
                return false;
            }

            if (!SecurityUtil.isValidString(history.Reason))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("reason"));
                }));
                return false;
            }

            if (!SecurityUtil.isValidString(history.Diagnose))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("diagnose"));
                }));
                return false;
            }

            return true;
        }

        public static bool isValidDiagnose(string diagnose)
        {
            if (!SecurityUtil.isValidString(diagnose))
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
                {
                    Messenger.ShowMessage(SecurityUtil.getErrorMessage("diagnose"));
                }));
                return false;
            }
            return true;
        }
    }
}
