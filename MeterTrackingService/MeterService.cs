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
            // Retrieve PK.
            var unitNumber = request.UnitNumber;

            // Retrieve obj from IMDB based on PK.            
            var imdb = (InMemoryDB) Session[unitNumber];
            if (imdb == null)
            {
                imdb = new InMemoryDB();
            }

            if (request.MeterReading > 0)
            {
                imdb.CurrentMeterReading = request.MeterReading;
            }
            if (request.FuelPurchaseAmount > 0)
            {
                imdb.TotalFuelPurchaseAmount += request.FuelPurchaseAmount;
            }

            // Save obj to IMDB.
            Session[unitNumber] = imdb;

            // Return repsonse obj.
            return new MeterResponse {Id = 1};
        }
    }

    class InMemoryDB
    {
        public InMemoryDB()
        {
            TotalFuelPurchaseAmount = 0.0;
            CurrentMeterReading = 0;
        }

        public double TotalFuelPurchaseAmount { get; set; }
        public int CurrentMeterReading { get; set; }

    }
}