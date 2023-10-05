using FlightsWebApp.DBContext;
using FlightsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlightsWebApp.Repository
{
    public class FlightsRepository:IFlightsRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public FlightsRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<FlightDetailsDTO> GetFlightDetails(UserInputs userInputs)
        {
            try
            {

                var query = from flight in _dbContext.Flights
                            where flight.Source == userInputs.Source && flight.Destination == userInputs.Destination
                            && flight.D_Date>= userInputs.DepartureDate
                            join airline in _dbContext.Airlines
                            on flight.AirlinesId equals airline.AirlinesId
                            select new FlightDetailsDTO
                            {
                                AirlinesId = flight.AirlinesId,
                                AirlinesName = airline.AirlinesName,
                                DepartureDate = flight.D_Date,
                                DepartureTime = flight.D_Time,
                                ArrivalDate = flight.A_Date,
                                ArrivalTime = flight.A_Time,
                                Price = flight.Price
                            };
                return query.ToList();
            }
            
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        public string UpdateFlightPrice(UserInputs userInputs)
        {

            Flights flights = _dbContext.Flights.Where(x => x.Source == userInputs.Source && x.Destination == userInputs.Destination).First();
            flights.Price=userInputs.Price;
            _dbContext.SaveChanges();
                              
            return "success";

        }
        public string DeleteFlightsRecord(UserInputs userInputs) 
        {
            Flights flights = _dbContext.Flights.Where(x => x.Source == userInputs.Source && x.Destination == userInputs.Destination
                               && x.AirlinesId == userInputs.AirlinesId).OrderBy(x=>x.FlightsId).Last();
            _dbContext.Remove(flights);
            
            _dbContext.SaveChanges();
            return "success";
        }
    }
   
}
