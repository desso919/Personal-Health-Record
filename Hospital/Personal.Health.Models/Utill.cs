using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Models
{
    public static class Utill
    {
        public static string formatDate(DateTime date)
        {
            if (date == null) return null;
            return String.Format("{0:f}", date);
        }
    }
}
