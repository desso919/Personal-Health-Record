using Hospital.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;

namespace Personal.Health.Record.Models
{
    public class PatientDetailsModel
    {
        public Patient getPatient(object id)
        {
            IPatientService patientService = new PatientService();
            Patient patient = patientService.getPatient(Convert.ToInt64(id));
            return patient;
        }
    }
}
