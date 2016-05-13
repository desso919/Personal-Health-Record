using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Models
{
    public class RecommendedVisitation
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public string Recurrency { get; set; }

        public string Description { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }
    }
}
