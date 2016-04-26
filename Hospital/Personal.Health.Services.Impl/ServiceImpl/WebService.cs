using Personal.Health.Services.Impl.HospitalServiceReference;
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
        private static HospitalWebServiceClient instance;

        public static HospitalWebServiceClient getInstance()
        {
            lock (syncLock)
            {
                if(instance == null) 
                {
                    instance = new HospitalWebServiceClient();
                }
                 return instance;
            }     
        }
    }
}
