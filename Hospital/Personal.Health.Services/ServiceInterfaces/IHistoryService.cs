using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services
{
    public interface IHistoryService
    {
        History GetHistory(long id);

        List<History> GetAllHistoryForThisPatient(long patientId);

        List<History> GetAllHistoryFromHospital(long hospitalId);

        List<History> GetAllHistoryByDoctor(long doctorId);

        Boolean addHistory(History history);
    }
}
