using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace MeterTrackingService
{
    [Route("/meter", "POST")]
    [Route("/meter/{UnitNumber}/{Time}/{MeterReading}", "POST")]
    public class Meter : IReturn<MeterResponse>
    {
        public string UnitNumber { get; set; }
        public DateTime Time { get; set; }
        public int MeterReading { get; set; }
        public double FuelPurchaseAmount { get; set; }
    }

    public class MeterResponse
    {
        public int Id { get; set; }        
    }

}