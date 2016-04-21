using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl
{
    public class HospitalService : IHospitalService
    {
        public List<HospitalModel> getAllHispitals()
        {
            HospitalModel hospital = new HospitalModel();
            hospital.Name = " Tokuda Hospital";
            hospital.Address = "Na mainata si";
            List<HospitalModel> hospitals = new List<HospitalModel>();
            hospitals.Add(hospital);
            return hospitals;
        }
    }
}
