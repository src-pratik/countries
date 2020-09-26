using Basics.Countries.Entities;
using Basics.Countries.MongoStorage;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Basics.Countries.Data
{
    public class Seeding
    {
        private CountryService _countryService;
        private FlagService _flagService;

        private string countriesJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "countries.json");
        private string flagFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "Flags", "png1000");

        public Seeding(CountryService countryService, FlagService flagService)
        {
            _countryService = countryService;
            _flagService = flagService;
        }

        public bool Run()
        {
            if (_countryService.Get().Count > 0)
                return false;

            var jsonData = File.ReadAllText(countriesJsonPath);
            var seedCountries = JsonConvert.DeserializeObject<List<Country>>(jsonData);

            foreach (var country in seedCountries)
            {
                var output = _countryService.Create(country);

                var imagepath = Path.Combine(flagFolderPath, $"{country.Alpha2Code}.png");
                if (File.Exists(imagepath))
                {
                    var flagImage = File.ReadAllBytes(imagepath);

                    _flagService.Create(new FlagImage() { Id = output.Id, Value = flagImage });
                }
            }

            return true;
        }
    }
}