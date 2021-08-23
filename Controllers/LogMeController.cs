using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogMeController : ControllerBase
    {

        public class ComplexType
        {
            public string Param1 { get; set; }
            public string Param2 { get; set; }
        }

        public void Post([FromBody] ComplexType complexType)
        {
            //do something
        }
    }
}
