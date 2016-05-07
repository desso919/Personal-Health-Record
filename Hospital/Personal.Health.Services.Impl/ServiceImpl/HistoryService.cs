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
            IDoctorService doctorService = new DoctorService();
            IHospitalService hospitalService = new HospitalService();
            List<History> histories = JsonConvert.DeserializeObject<List<History>>(WebService.getInstance().GetHospitalRecordByPatientID(patientId));
            
            foreach (History history in histories)
            {
                HospitalModel hospital = hospitalService.GetHispital(history.HospitalId);
                Doctor doctor = doctorService.getDoctor(history.DoctorId);
                history.Doctor = doctor.FirstName + " " + doctor.SecondName + " " + doctor.LastName;
                history.Hospital = hospital.Name;
            }
            return  histories;
        }

        public bool addHistory(History history)
        {
            return true;
        }
    }
}
