using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PriceAnalyzerAPI.Application;
using PriceAnalyzerAPI.Interfaces;

namespace PriceAnalyzerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceAnalyzerController : ControllerBase
    {
        private readonly IFuturesDataProcessor _dataProcessor;

        public PriceAnalyzerController(IFuturesDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        [HttpGet("compare-prices")]
        public async Task<ActionResult<FuturesDeltaDTO>> ComparePrices()
        {
            var result = await _dataProcessor.CompareFuturesPrices();

            return Ok(result);
        }
    }
}
