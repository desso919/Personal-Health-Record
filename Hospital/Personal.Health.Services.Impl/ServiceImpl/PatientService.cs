using Hospital.Models;
using System;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;

namespace Personal.Health.Services.Impl
{
    public class PatientService : IPatientService
    {
        public Patient GetPatient(long id)
        {

            string result = WebService.getInstance().GetPatient(id);
            if (result.Equals(ServicesUtils.EMPTY_JSON)) { return null; }

            return JsonConvert.DeserializeObject<Patient>(result);
        }

        public Patient LoginWithUsername(string username, string password)
        {
            string result = WebService.getInstance().GetPatientByUsernameAndPassword(username, password);
            if (result.Equals(ServicesUtils.EMPTY_JSON)) { return null; }

            return JsonConvert.DeserializeObject<Patient>(result);
        }

        public Patient LoginWithEGN(string egn, string password)
        {
            string result = WebService.getInstance().GetPatientByEGNAndPassword(egn, password);
            if (result.Equals(ServicesUtils.EMPTY_JSON)) { return null; }

            return JsonConvert.DeserializeObject<Patient>(result);
        }

        public Boolean RegisterUser(Patient patient)
        {
            bool result = WebService.getInstance().AddNewPatient(patient.Username, patient.Password, patient.FirstName, patient.SecondName, patient.LastName, patient.EGN, patient.Gender, patient.Age, patient.BirhtDate);
            if (result.Equals(ServicesUtils.TRUE)) 
            { 
                return true; 
            }
            return false;
        }
    }
}
