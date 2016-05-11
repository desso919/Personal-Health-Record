using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.Utills
{
    public static class Utill
    {
        public static int GetAge(string birthday)
        {
            DateTime _birthday = Convert.ToDateTime(birthday);
            DateTime now = DateTime.Today;
            int age = now.Year - _birthday.Year;
            if (now < _birthday.AddYears(age)) age--;

            return age;
        }
    }
}
