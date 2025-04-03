using Microsoft.AspNetCore.Mvc;

namespace BTCFuturesTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {        
        //current quarter BTCUSDT_250627
        //next quarter BTCUSDT_250926

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;            
        }

        [HttpGet(Name = "GetFutures")]
        public async Task GetAsync()
        {
            //var response = await _btcfeaturesGetter.GetFuturesDataAsync("BTCUSDT_250627");
        }
    }
}
