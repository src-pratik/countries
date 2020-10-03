using Basics.Countries.Entities;
using Basics.Countries.MongoStorage;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Basics.Countries.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlagController : ControllerBase
    {
        private readonly FlagService _flagService;

        public FlagController(FlagService flagService)
        {
            _flagService = flagService;
        }


        [HttpGet()]
        public IActionResult Get()
        {
            var result = _flagService.Get();

            if (result == null)
                return NoContent();

            var data = result.Select(x => new { Id = x.Id, Flag = System.Convert.ToBase64String(x.Value) }).ToList();

            return Ok(data);
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult GetById(string id)
        {
            var result = _flagService.Get(id);

            if (result == null)
                return NoContent();

            return Ok(new FlagImageDTO { Id = id, Flag = System.Convert.ToBase64String(result.Value) });
        }

        [HttpPost]
        public IActionResult Create(FlagImage flagImage)
        {
            flagImage = _flagService.Create(flagImage);

            return CreatedAtRoute("", new { id = flagImage.Id.ToString() }, flagImage);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, FlagImage flagImage)
        {
            var result = _flagService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            _flagService.Update(id, flagImage);

            return NoContent();
        }
    }
}