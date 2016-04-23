﻿using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services
{
    public interface IHistoryService
    {
         History getHistory(long id);

         List<History> getAllHistory();

         Boolean addHistory(History history);
    }
}
