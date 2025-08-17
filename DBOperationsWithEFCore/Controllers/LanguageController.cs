using DBOperationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public LanguageController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public IActionResult GetAllLanguages()
        {
            var result = from language in _appDBContext.Languages
                         select language;
            return Ok(result);
        }
    }
}
