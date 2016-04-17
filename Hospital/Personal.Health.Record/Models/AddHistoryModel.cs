using Hospital.Models;
using Personal.Health.Services;
using Personal.Health.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Record.Models
{
     public class AddHistoryModel
    {
         public Boolean addHistory(History history)
         {
             IHistoryService historyService = new HistoryService();
             Boolean isAdded = historyService.addHistory(history);
             return isAdded;
         }
    }
}
