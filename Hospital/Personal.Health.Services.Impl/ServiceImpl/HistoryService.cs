using Hospital.Models;
using System;
using System.Collections.Generic;

namespace Personal.Health.Services.Impl
{
    public class HistoryService : IHistoryService
    {
        public History getHistory(long id)
        {
            History history = new History();
            history.DoctorId = 1;
            history.HospitalId = 2;
            history.Date = new DateTime();
            history.Description = "Pregled";
            history.Reason = "Sifilis";
            history.Diagnose = "You will die soon!";
            return history;
        }

        public List<History> getAllHistory()
        {
            List<History> histories = new List<History>();
            History history = new History();

            history.DoctorId = 1;
            history.HospitalId = 2;
            history.Date = new DateTime();
            history.Description = "Pregled";
            history.Reason = "Sifilis";
            history.Diagnose = "You will die soon!";
            histories.Add(history);
            return histories;
        }

        public bool addHistory(History history)
        {
            return true;
        }
    }
}
