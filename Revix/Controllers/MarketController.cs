using Microsoft.AspNetCore.Mvc;
using Revix.Models;
using Revix.Services.Contracts;
using Revix.Services.Services;
using System.Threading.Tasks;

namespace Revix.Controllers
{
    [ApiController]
    [Route("crypto/listing")]
    public class MarketController : ControllerBase
    {
        private readonly ICryptoService _service;
        public MarketController(ICryptoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrytoMarketData([FromQuery] CryptoListingSortDataVM cryptoListingSort)
        {
            return Ok(await _service.GetandSaveCryptoData(cryptoListingSort));
        }
    }
}
