using MeterTrackingService;
using ServiceStack.ServiceClient.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int iter = 1;
            string unitNumber = "";
            int meterReading = -1;
            DateTime dt = DateTime.Now;
            double fuelPurchaseAmount = -1;

            Console.WriteLine("Enter unit number:");
            unitNumber = Console.ReadLine();

            var client = new JsonServiceClient("http://localhost:57526/");

            while (iter > 0)
            {

                Console.WriteLine("Enter meter reading:");
                meterReading = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Fuel Purchase amount:");
                fuelPurchaseAmount = double.Parse(Console.ReadLine());

                var response = client.Send(
                    new Meter
                    {
                        UnitNumber = unitNumber,
                        Time = dt,
                        MeterReading = meterReading,
                        FuelPurchaseAmount = fuelPurchaseAmount
                    });
                Console.WriteLine("Response : " + response.Id);

                Console.WriteLine("Enter 0 to stop enter meter reading");
                iter = int.Parse(Console.ReadLine());

                /* Async version
                client.SendAsync(
                    new Meter
                    {
                        UnitNumber = unitNumber,
                        Time = dt,
                        MeterReading = meterReading,
                        FuelPurchaseAmount = fuelPurchaseAmount
                    },
                    meterResponse => {
                        Console.WriteLine("Enter 0 to stop enter meter reading");
                        iter = int.Parse(Console.ReadLine());
                    },
                    (meterResponse, excpetion) => Console.WriteLine("Error: " + excpetion.Message)
                );
                */

            }

            MeterQueryResponse meterQueryResponse = null;
            try
            {
                meterQueryResponse = client.Post(
                    new MeterQuery
                    {
                        UnitNumber = unitNumber
                    });
                Console.WriteLine("CurrentMeterReading : " + meterQueryResponse.CurrentMeterReading);
                Console.WriteLine("TotalFuelPurchaseAmount : " + meterQueryResponse.TotalFuelPurchaseAmount);
            }
            catch (WebServiceException ex)
            {
                Console.WriteLine(ex.ErrorMessage); 
            }

            Console.WriteLine("Enter 0 to exit the program");
            iter = int.Parse(Console.ReadLine());

        }
    }
}
