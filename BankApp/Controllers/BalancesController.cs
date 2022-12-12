using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using BankApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly BankContext _context;
        private readonly IBalanceRepository _balanceRepository;
        private readonly IDistributedCache _cache;
        private readonly ILogger<BalancesController> _logger;
        //private static readonly SemaphoreSlim semaphore = new(1, 1);

        public BalancesController(BankContext context, IBalanceRepository balanceRepository, IDistributedCache cache, ILogger<BalancesController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _balanceRepository = balanceRepository ?? throw new ArgumentNullException(nameof(balanceRepository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<BalancesController>
        [HttpGet]
        public IAsyncEnumerable<Balance> Get()
        {
            return _balanceRepository.Get();
            //var items = _context.BankTransactions.AsAsyncEnumerable();
            //await foreach (var item in items)
            //{
            //    yield return item;
            //}
        }

        // GET api/<BalancesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Balance?>> Get(int id)
        {
            return Ok(await _balanceRepository.Find(id));
        }

        // POST api/<BalancesController>
        [HttpPost]
        public async Task<ActionResult<Balance>> Post([FromBody] Balance value)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            _balanceRepository.Add(value);
            await _balanceRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBalance", new { id = value.AccountId }, value);
        }

        // PUT api/<BalancesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Balance value)
        {
            if (id != value.BalanceId)
            {
                return BadRequest();
            }

            _balanceRepository.Update(value);

            try
            {
                await _balanceRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _balanceRepository.Find(id);
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

        // DELETE api/<BalancesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _balanceRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _balanceRepository.Delete(item);
            await _balanceRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
