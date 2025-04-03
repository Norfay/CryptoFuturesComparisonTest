using Microsoft.AspNetCore.Mvc;
using SchedulerAPI.Interfaces;

namespace SchedulerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulerController : ControllerBase
    {
        private readonly IPriceComparisonJob _comparisonJob;

        public SchedulerController(IPriceComparisonJob comparisonJob)
        {
            _comparisonJob = comparisonJob;
        }

        [HttpGet]
        public ActionResult JobTest()
        {
            _comparisonJob.Execute();
            return Ok();
        }
    }
}
