using Hospital.Models;
using Personal.Health.Services.Impl.HospitalServiceReference;
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
            //HospitalWebServiceClient serviceReference = new HospitalWebServiceClient();
            //string response = serviceReference.
            //Patient m = JsonConvert.DeserializeObject<Patient>(json);

            HospitalWebServiceClient client = new HospitalWebServiceClient();
            string response = client.GetPatient(1);

            //Hospital.Models.Patient pat = Newtonsoft.JsonConvert.DeserializeObject<Hospital.Models.Patient>(response);
            //pat.Id = 1;
            //pat.Username = "desko";
            //pat.FirstName = "Desislav";
            //pat.SecondName = "Andreev";
            //pat.LastName = "Hristov";
            //pat.EGN = "9403082343";
            //pat.Gender = "Male";
            //pat.Age = 22;
            //pat.BirhtDate = new DateTime().ToShortDateString();
            return null;
        }
    }
}
