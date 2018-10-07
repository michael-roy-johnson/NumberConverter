using Microsoft.AspNetCore.Mvc;
using NumberConverter.Services;

namespace NumberConverter.API.Controllers
{
    [Produces("application/json")]
    [Route("api/converter")]
    public class ConverterController : Controller
    {
        private readonly IConverterService _converterService;

        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        // GET: api/converter/{number}
        [HttpGet("{number}")]
        public string Get(int number)
        {
            return _converterService.NumberToWords(number);
        }
    }
}
