using Basics.Countries.Data;
using Basics.Countries.MongoStorage;
using System;
using System.Diagnostics;

namespace Basics.Countries.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CountryDBSettings countryDBSettings = new CountryDBSettings()
            {
                ConnectionString = "mongodb://127.0.0.1:27017",
                DatabaseName = "CountryDB"
            };
        
            FlagService flagService = new FlagService(countryDBSettings);
            CountryService countryService = new CountryService(countryDBSettings);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            var dataSeeding = new Seeding(countryService, flagService);
            dataSeeding.Run();
            sw.Stop();

            Console.WriteLine($"Load Complete : {sw.Elapsed.TotalSeconds}");

            Console.ReadKey();
        }
    }
}