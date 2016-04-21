using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl
{
    public class PatientService : IPatientService
    {
        public Hospital.Models.Patient getPatient(long id)
        {
            Patient pat = new Patient();
            pat.Id = 1;
            pat.Username = "desko";
            pat.FirstName = "Desislav";
            pat.SecondName = "Andreev";
            pat.LastName = "Hristov";
            pat.EGN = "9403082343";
            pat.Gender = "Male";
            pat.Age = 22;
            pat.BirhtDate = new DateTime().ToShortDateString();
            return pat;
        }
    }
}
