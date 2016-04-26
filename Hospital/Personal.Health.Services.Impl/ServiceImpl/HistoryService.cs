using Hospital.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Personal.Health.Services.Impl.HospitalServiceReference;
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
            return JsonConvert.DeserializeObject<List<History>>(WebService.getInstance().GetHospitalRecordByPatientID(patientId));
        }

        public List<History> GetAllHistoryFromHospital(long hospitalId)
        {
            return JsonConvert.DeserializeObject<List<History>>(WebService.getInstance().GetHospitalRecordByHospitalID(hospitalId));
        }

        public List<History> GetAllHistoryByDoctor(long doctorId)
        {
            return JsonConvert.DeserializeObject<List<History>>(WebService.getInstance().GetHospitalRecordByDoctorID(doctorId));
        }

        public bool addHistory(History history)
        {
            return true;
        }
    }
}
