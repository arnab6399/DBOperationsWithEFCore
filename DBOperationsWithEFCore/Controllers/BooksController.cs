using DBOperationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDBContext appDBContext) : ControllerBase
    {
        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooks()
        {
            return Ok();
        }
    }
}
