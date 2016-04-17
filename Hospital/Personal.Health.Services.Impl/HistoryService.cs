using Hospital.Models;
using System;

namespace Personal.Health.Services.Impl
{
    public class HistoryService : IHistoryService
    {
        public History getHistory(long id)
        {
            History history = new History();
            history.Date = new DateTime();
            history.Description = "Pedal";
            history.Reason = "Sex";
            return history;
        }

        public bool addHistory(History history)
        {
            return true;
        }
    }
}
