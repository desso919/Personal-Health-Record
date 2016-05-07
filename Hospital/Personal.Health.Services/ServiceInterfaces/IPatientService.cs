using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services
{
    public interface IPatientService
    {
        Patient GetPatient(long id);

        Patient LoginWithUsername(string username, string password);

        Patient LoginWithEGN(string username, string password);

        Boolean RegisterUser(Patient patientToBeAdded);
    }
}
