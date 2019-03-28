using Microsoft.AspNetCore.Mvc;
using Motorola.MotoTaxi.Locations.DomainModels;
using Motorola.MotoTaxi.Locations.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Locations.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] double lat, [FromQuery] double lng)
        {
            var myLocation = new Location(lat, lng);

            var locations = locationService.Get(myLocation);

            if (!locations.Any())
            {
                return NotFound();
            }

            return Ok(locations);
        }

        [HttpPost]
        public IActionResult Post(VehicleLocation vehicleLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            locationService.Add(vehicleLocation);

            return CreatedAtRoute(new { Id = vehicleLocation.DeviceId }, vehicleLocation);
        }
    }
}
