using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;

namespace MeterTrackingService
{
    public class MeterService : Service 
    {
        public object Post(Meter request)
        {
            return new MeterResponse {Id = 1};
        }
    }
}