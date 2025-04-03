using DataCollectorAPI.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DataCollectorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataCollectorController : ControllerBase
    {
        private readonly IFuturesDataService _futuresDataService;

        public DataCollectorController(IFuturesDataService futuresDataService)
        {
            _futuresDataService = futuresDataService;
        }

        [HttpGet("get-yesterday-prices/{ticker}")]
        public async Task<ActionResult<KlineResponseDTO>> GetYesterdayFuturesData(string ticker)
        {
            var data = await _futuresDataService.GetFuturesDataAsync(ticker, DateTime.UtcNow.AddDays(-1).Date);
            if (data == null) return NotFound("Cant get futures data");
            return Ok(data);
        }
    }
}
