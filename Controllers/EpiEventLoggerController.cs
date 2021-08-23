using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLogApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpiEventLoggerController : ControllerBase
    {
        private IEpiStepEventLoggerRepository _epiStepEventLoggerRepository;

        public EpiEventLoggerController(IEpiStepEventLoggerRepository epiStepEventLoggerRepository)
        {
            _epiStepEventLoggerRepository = epiStepEventLoggerRepository;
        }

        [HttpPost("PostEpiplexStep")]
        public IActionResult PostEpiplexStep([FromBody] EpiplexStep epiplexStep)
        {
            try
            {
                bool insertEvent = _epiStepEventLoggerRepository.InsertEpiStepLog(epiplexStep);

                if (insertEvent)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error while inserting event");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error while inserting event" + ex.Message);
            }
        }

        [HttpPost("PostUniqueStep")]
        public IActionResult PostUniqueStep([FromBody] UniqueStep uniqueStep)
        {
            try
            {
                bool insertEvent = _epiStepEventLoggerRepository.InsertUniqueStepLog(uniqueStep);

                if (insertEvent)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error while inserting event");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error while inserting event" + ex.Message);
            }
        }

    }

}
