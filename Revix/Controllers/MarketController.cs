using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Revix.Controllers
{
    public class MarketController : ControllerBase
    {
        public MarketController()
        {

        }
        public IActionResult GetCrytoMarketData()
        {
            return Ok();
        }
    }
}
