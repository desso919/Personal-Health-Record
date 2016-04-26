using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Record.ViewModels
{
    public sealed class LoggedInPatient
    {
        private static readonly object syncLock = new object();
        private static Patient loggedInPatient;

        public static void Init(Patient patient)
        {
            if (patient != null)
            {
                loggedInPatient = patient;
            }
        }

        public static Patient GetPatient()
        {
            lock (syncLock)
            {
                return loggedInPatient;
            }     
        }  
    }
}
