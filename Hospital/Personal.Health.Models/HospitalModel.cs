using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class HospitalModel
    {
        public long HospitalId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", HospitalId, Name, Address);
        }
    }
}
