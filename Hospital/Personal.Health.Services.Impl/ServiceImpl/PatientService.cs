using Hospital.Models;
using Personal.Health.Services.Impl.HospitalServiceReference;
using System;
using Newtonsoft.Json;
using Personal.Health.Services.Impl.ServiceImpl;

namespace Personal.Health.Services.Impl
{
    public class PatientService : IPatientService
    {
        public Patient GetPatient(long id)
        {
            return JsonConvert.DeserializeObject<Patient>(WebService.getInstance().GetPatient(id));
        }

        public Patient Login(string username, string password)
        {
            return JsonConvert.DeserializeObject<Patient>(WebService.getInstance().GetPatientByUsernameAndPassword(username, password));
        }

        public Boolean RegisterUser(Patient patientToBeAdded)
        {
            return true;
        }
    }
}
