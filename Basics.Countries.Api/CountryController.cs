using Basics.Countries.Entities;
using Basics.Countries.MongoStorage;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Countries.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_countryService.Get());
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            Projections include = new Projections()
            {
                Type = ProjectionTypeEnum.Include,
                FieldNames = new[] { nameof(Country.Id), nameof(Country.Name) }
            };

            return Ok(_countryService.Get(include));
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult GetById(string id)
        {
            var result = _countryService.Get(id);

            if (result == null)
                NoContent();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            country = _countryService.Create(country);

            return CreatedAtRoute(nameof(GetById), new { id = country.Id.ToString() }, country);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Country country)
        {
            var result = _countryService.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            _countryService.Update(id, country);

            return NoContent();
        }
    }
}