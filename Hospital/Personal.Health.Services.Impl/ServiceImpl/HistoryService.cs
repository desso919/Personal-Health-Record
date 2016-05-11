using Hospital.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Personal.Health.Services.Impl.HospitalWebService;
using Personal.Health.Services.Impl.ServiceImpl;
using System;
using System.Collections.Generic;

namespace Personal.Health.Services.Impl
{
    public class HistoryService : IHistoryService
    {
        public History GetHistory(long id)
        {
            return JsonConvert.DeserializeObject<History>(WebService.getInstance().GetHospitalRecord(id));
        }

        public List<History> GetAllHistoryForThisPatient(long patientId)
        {
            string response = WebService.getInstance().GetHospitalRecordByPatientID(patientId);
            if (response.Equals(ServicesUtils.EMPTY_JSON))
            {
                return new List<History>();
            }

            return JsonConvert.DeserializeObject<List<History>>(response);       
        }

        public bool addHistory(History history)
        {
            bool isAdded = WebService.getInstance().AddNewHospitalRecord(history.Patient.Id, history.Hospital.HospitalId, history.Doctor.DoctorId, history.Reason, history.Diagnose, history.Date, history.Description);

            if(isAdded)
            {
                return true;
            }
            return false;
        }

    }
}
