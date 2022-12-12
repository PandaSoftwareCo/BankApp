using AutoMapper;
using BankApp.Application.Common.Interfaces;
using BankApp.Application.DTOs;
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
    public class AccountsController : ControllerBase
    {
        private const string employeeListCacheKey = "accountList";
        private readonly BankContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly ILogger<AccountsController> _logger;
        //private static readonly SemaphoreSlim semaphore = new(1, 1);

        public AccountsController(BankContext context, IAccountRepository accountRepository, IMapper mapper, IDistributedCache cache, ILogger<AccountsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public IAsyncEnumerable<Account> Get()
        {
            return _accountRepository.Get();
            //return _context.Accounts.AsAsyncEnumerable();
            //await foreach (var item in _accountRepository.Get())
            //{
            //    yield return item;
            //}
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto?>> Get(int id)
        {
            return Ok(_mapper.Map<AccountDto>(await _accountRepository.FindAsync(id)));
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<ActionResult<Account>> Post([FromBody] Account value)
        {
            _accountRepository.Add(value);
            await _accountRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = value.AccountId }, value);
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Account value)
        {
            if (id != value.AccountId)
            {
                return BadRequest();
            }

            _accountRepository.Update(value);

            try
            {
                await _accountRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _accountRepository.FindAsync(id);
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

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _accountRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _accountRepository.Delete(item);
            await _accountRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
