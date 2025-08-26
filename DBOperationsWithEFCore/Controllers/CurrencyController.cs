using DBOperationsWithEFCore.Data;
using DBOperationsWithEFCore.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public CurrencyController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = _appDBContext.Currencies.ToList();
            var result =await (from currency in _appDBContext.Currencies
                         select currency).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync(int id)
        {
            var result =await _appDBContext.Currencies.FindAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetCurrencyByMultipleIdAsync([FromBody] List<int> ids)
        {
            var result = await _appDBContext.Currencies.Where(x => ids.Contains(x.CurrencyId)).ToListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("SpecificColumn")]
        public async Task<IActionResult> GetSpecificColumnCurrencyAsync()
        {
            //var result = await _appDBContext.Currencies.Where(x => ids.Contains(x.CurrencyId)).ToListAsync();

            var result = await (from currency in _appDBContext.Currencies select new Currency()
            {
                CurrencyId = currency.CurrencyId,
                Title =currency.Title
            }).ToListAsync();
            //anonymous property
            var result2 = await (from currency in _appDBContext.Currencies
                                select new 
                                {
                                    CurrId = currency.CurrencyId,
                                    name = currency.Title
                                }).ToListAsync();

            var result1 = await (from currency in _appDBContext.Currencies select currency).Select(x => new CurrencyDTO()
            {
                CurrencyDTOId = x.CurrencyId,
                CurrencyDTOTitle = x.Title
            }).ToListAsync();
            if (result2 != null)
            {
                return Ok(result2);
            }
            else
            {
                return NotFound();
            }
        }

        //[Route("GetCurrencyByName")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string name)
        {
            var result = await _appDBContext.Currencies.FirstOrDefaultAsync(x => x.Title == name);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[Route("GetCurrencyByDesc")]
        [HttpGet("GetByQueryString/{name}")]
        public async Task<IActionResult> GetCurrencyByNameAndDescWithQueryStringAsync([FromRoute] string name, [FromQuery] string? description)
        {
            //var result = await _appDBContext.Currencies.
            //    FirstOrDefaultAsync(x =>
            //    x.Title == name && 
            //    (String.IsNullOrEmpty(description) || x.Description == description));

            var result = await _appDBContext.Currencies.
                Where(x =>
                x.Title == name &&
                (String.IsNullOrEmpty(description) || x.Description == description)).ToListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{name}/{description}")]
        public async Task<IActionResult> GetCurrencyByNameAndDescAsync([FromRoute] string name, [FromRoute] string description)
        {
            var result = await _appDBContext.Currencies.
                FirstOrDefaultAsync(x => 
                x.Title == name && x.Description == description);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
