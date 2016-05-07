using Personal.Health.Services.Impl.HospitalWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.Impl.ServiceImpl
{
    public sealed class WebService
    {
        private static readonly object syncLock = new object();
        private static HospitalServiceClient instance;

        public static HospitalServiceClient getInstance()
        {
            lock (syncLock)
            {
                if(instance == null) 
                {
                    instance = new HospitalServiceClient();
                }
                 return instance;
            }     
        }
    }
}
