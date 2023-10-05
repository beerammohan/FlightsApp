using FlightsWebApp.Models;
using FlightsWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsRepository _flightsRepository;
        public FlightsController(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }
        // GET: api/<FlightsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<FlightsController>/5
        [HttpGet]
        public IActionResult GetFlightDetails(string source, string destination, string date)
        {
            try
            {
                UserInputs userInputs = new UserInputs();
                userInputs.Source = source;
                userInputs.Destination = destination;
                DateTime dt =
                    DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var flightDetails = _flightsRepository.GetFlightDetails(userInputs);
                return Ok(flightDetails);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //POST api/<FlightsController>
        [HttpPost]
        public string Post([FromBody] UserInputs userInputs)
        {
             return _flightsRepository.UpdateFlightPrice(userInputs);
            
        }

        //PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //DELETE api/<FlightsController>/5
        [HttpDelete]
        public string Delete(UserInputs userInputs)
        {
            return _flightsRepository.DeleteFlightsRecord(userInputs);
        }
    }
}
