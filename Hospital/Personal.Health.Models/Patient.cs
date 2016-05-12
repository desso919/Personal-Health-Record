using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        private const string MALE = "Male";
        private const string FEMALE = "Female";
        private bool isMale;


        public Patient()
        {
            isMale = true;           
        }

        public bool IsMale { get { return isMale; } set { isMale = value; } }
        public string Gender 
        { 
            get 
            {
                if (IsMale)
                {
                    return MALE; 
                }
                return FEMALE;
            }
        }

        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string EGN { get; set; }

        public int Age { get; set; }

        public string BirhtDate { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1} {2}", FirstName, SecondName, LastName); }
        }

        public string WelcomeUser
        {
            get { return string.Format("Welcome,  {0} {1}", FirstName, LastName); }
        }
    }

}
