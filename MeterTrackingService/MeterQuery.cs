using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeterTrackingService
{
    [Route("/MeterQuery")]
    public class MeterQuery : IReturn<MeterQueryResponse>
    {
        public string UnitNumber { get; set; }
    }

    public class MeterQueryResponse
    {
        public double TotalFuelPurchaseAmount { get; set; }
        public int CurrentMeterReading { get; set; }

        // Process exception
        public ResponseStatus ResponseStatus { get; set; }
    }
}