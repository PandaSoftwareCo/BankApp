using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using BankApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BankContext _context;
        private readonly ICategoryRepository _categoryRepository;
        //private readonly IDistributedCache _cache;
        private readonly ILogger<CategoriesController> _logger;
        //private static readonly SemaphoreSlim semaphore = new(1, 1);

        public CategoriesController(BankContext context, ICategoryRepository categoryRepository, /*IDistributedCache cache,*/ ILogger<CategoriesController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            //_cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IAsyncEnumerable<Category> Get()
        {
            return _categoryRepository.Get();
            //return _context.Categories.AsAsyncEnumerable();
            //var items = _context.BankTransactions.AsAsyncEnumerable();
            //await foreach (var item in items)
            //{
            //    yield return item;
            //}
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Category?> Get(int id)
        {
            return await _categoryRepository.Find(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category value)
        {
            _categoryRepository.Add(value);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = value.CategoryId }, value);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category value)
        {
            if (id != value.CategoryId)
            {
                return BadRequest();
            }

            _categoryRepository.Update(value);

            try
            {
                await _categoryRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _categoryRepository.Find(id);
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

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _categoryRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(item);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
