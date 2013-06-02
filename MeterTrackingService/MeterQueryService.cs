using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeterTrackingService
{
    public class MeterQueryService : Service
    {
        public object Any(MeterQuery request)
        {
            return new MeterQueryResponse { TotalFuelPurchaseAmount = 120.50, CurrentMeterReading = 2000 };
        }
    }
}