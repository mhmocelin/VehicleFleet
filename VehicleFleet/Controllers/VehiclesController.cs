using Microsoft.AspNetCore.Mvc;
using VehicleFleet.Domain.Services;
using VehicleFleet.Domain.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VehicleFleet.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehiclesController(IVehicleService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateVehicleRequest request)
        {
            try
            {
                _service.Add(request);                
                return CreatedAtAction(nameof(GetByChassis), new { series = request.ChassisId.Series, number = request.ChassisId.Number }, request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{series}/{number}")]
        public IActionResult GetByChassis(string series, uint number)
        {
            var vehicle = _service.GetByChassis(series, number);
            return vehicle is null ? NotFound() : Ok(vehicle);
        }

        [HttpPut("{series}/{number}/color")]
        public IActionResult UpdateColor(string series, uint number, ColorUpdateRequest request)
        {
            try
            {
                var success = _service.UpdateColor(series, number, request);
                return success ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
