using DatabaseAPI.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly IFuturesDeltaRepository _repository;

        public DatabaseController(IFuturesDeltaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("save-price-difference")]
        public async Task<ActionResult> SavePriceDifference([FromBody] FuturesDeltaDTO delta)
        {
            if (delta == null) return BadRequest("Invalid data");

            var entity = new FuturesDeltaEntity
            {
                ComparingTime = delta.ComparingTime,
                OpenPrice = delta.OpenPrice,
                HighPrice = delta.HighPrice,
                LowPrice = delta.LowPrice,
                ClosePrice = delta.ClosePrice
            };

            await _repository.SaveAsync(entity);
            return Ok("Data saved");
        }
    }
}
