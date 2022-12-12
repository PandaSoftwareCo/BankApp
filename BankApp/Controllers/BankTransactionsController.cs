using AutoMapper;
using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using BankApp.Data.Repositories;
using BankApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BankTransactionsController : ControllerBase
    {
        private const string transactionListCacheKey = "transactionList";
        private readonly BankContext _context;
        private readonly IBankTransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly ILogger<BankTransactionsController> _logger;
        //private static readonly SemaphoreSlim semaphore = new(1, 1);

        public BankTransactionsController(BankContext context, IBankTransactionRepository transactionRepository, IMapper mapper, IDistributedCache cache, ILogger<BankTransactionsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<BankTransactionsController>
        [HttpGet]
        public IAsyncEnumerable<BankTransaction> Get()
        {
            //if (_cache.TryGetValue(transactionListCacheKey, out IEnumerable<BankTransaction>? transactions))
            //{

            //}
            return _transactionRepository.Get();
            //return _context.BankTransactions.AsAsyncEnumerable();
            //var items = _context.BankTransactions.AsAsyncEnumerable();
            //await foreach (var item in items)
            //{
            //    yield return item;
            //}
        }

        // GET: api/<BankTransactionsController>
        [HttpGet("[action]")]
        public ActionResult<IAsyncEnumerable<BankTransaction>> GetTransactions()
        {
            return Ok(_transactionRepository.GetTransactions());
        }

        // GET api/<BankTransactionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankTransaction>> Get(int id)
        {
            var item = await _transactionRepository.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/<BankTransactionsController>
        [HttpPost]
        public async Task<ActionResult<BankTransaction>> Post([FromBody] BankTransaction value)
        {
            _transactionRepository.Add(value);
            await _transactionRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBankTransaction", new { id = value.BankTransactionId }, value);
        }

        // PUT api/<BankTransactionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourList(int id, [FromBody] BankTransaction value)
        {
            if (id != value.BankTransactionId)
            {
                return BadRequest();
            }

            _transactionRepository.Update(value);

            try
            {
                await _transactionRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _transactionRepository.FindAsync(id);
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

        // DELETE api/<BankTransactionsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _transactionRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _transactionRepository.Delete(item);
            await _transactionRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
