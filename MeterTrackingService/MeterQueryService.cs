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
            // Retrieve PK.
            var unitNumber = request.UnitNumber;

            // Retrieve obj from IMDB based on PK.            
            var imdb = (InMemoryDB) Session[unitNumber];
            if (imdb == null)
            {
                imdb = new InMemoryDB();
            }

            if (unitNumber == "100")
            {
                throw new NotImplementedException("This is a test");
            }

            // Return repsonse obj.
            return new MeterQueryResponse { 
                TotalFuelPurchaseAmount = imdb.TotalFuelPurchaseAmount, 
                CurrentMeterReading = imdb.CurrentMeterReading 
            };
        }
    }
}