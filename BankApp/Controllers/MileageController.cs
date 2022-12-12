using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using BankApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BankApp.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MileageController : ControllerBase
    {
        private readonly BankContext _context;
        private readonly IMileageRepository _mileageRepository;
        private readonly IDistributedCache _cache;
        private readonly ILogger<MileageController> _logger;

        public MileageController(BankContext context, IMileageRepository mileageRepository, IDistributedCache cache, ILogger<MileageController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mileageRepository = mileageRepository ?? throw new ArgumentNullException(nameof(mileageRepository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<MileageController>
        [HttpGet]
        public IAsyncEnumerable<Mileage> Get()
        {
            return _mileageRepository.Get();
        }

        // GET api/<MileageController>/5
        [HttpGet("{id}")]
        public async Task<Mileage?> Get(int id)
        {
            return await _mileageRepository.Find(id);
        }

        // POST api/<MileageController>
        [HttpPost]
        public async Task<ActionResult<Mileage>> Post([FromBody] Mileage value)
        {
            _mileageRepository.Add(value);
            await _mileageRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMileage", new { id = value.MileageId }, value);
        }

        // PUT api/<MileageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Mileage value)
        {
            if (id != value.MileageId)
            {
                return BadRequest();
            }

            _mileageRepository.Update(value);

            try
            {
                await _mileageRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _mileageRepository.Find(id);
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

        // DELETE api/<MileageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _mileageRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _mileageRepository.Delete(item);
            await _mileageRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
