using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietApp.DataAccessLayer;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DietApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(AuthenticationContext context)
        {

        }
        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" }; 
        }
    }
}
