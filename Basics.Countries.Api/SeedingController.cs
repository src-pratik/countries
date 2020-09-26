using Basics.Countries.Data;
using Basics.Countries.MongoStorage;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Basics.Countries.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedingController : ControllerBase
    {
        private readonly CountryService _countryService;
        private readonly FlagService _flagService;
        private Seeding _seeding;

        public SeedingController(CountryService countryService, FlagService flagService)
        {
            _countryService = countryService;
            _flagService = flagService;
            _seeding = new Seeding(_countryService, _flagService);
        }

        [HttpGet("run")]
        public IActionResult Run()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var output = _seeding.Run();
            sw.Stop();
            return Ok($"Data Seeding Completed. Status : {output} Time Taken {sw.Elapsed}");
        }
    }
}