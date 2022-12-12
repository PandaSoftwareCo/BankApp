using AutoMapper;
using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using BankApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

namespace BankApp.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly BankContext _context;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(BankContext context, IVehicleRepository vehicleRepository, IMapper mapper, IDistributedCache cache, ILogger<VehicleController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<VehicleController>
        /// <summary>
        /// This method returns a list of vehicles
        /// </summary>
        /// <returns>IAsyncEnumerable</returns>
        [HttpGet]
        public ActionResult<IAsyncEnumerable<Vehicle>> Get()
        {
            return Ok(_vehicleRepository.Get());
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<Vehicle?> Get(int id)
        {
            return await _vehicleRepository.FindAsync(id);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post([FromBody] Vehicle value)
        {
            _vehicleRepository.Add(value);
            await _vehicleRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = value.VehicleId }, value);
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vehicle value)
        {
            if (id != value.VehicleId)
            {
                return BadRequest();
            }

            _vehicleRepository.Update(value);

            try
            {
                await _vehicleRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _vehicleRepository.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _vehicleRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _vehicleRepository.Delete(item);
            await _vehicleRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
