using FlightsWebApp.Models;

namespace FlightsWebApp.Repository
{
    public interface IFlightsRepository
    {
        List<FlightDetailsDTO> GetFlightDetails(UserInputs userInputs);
        string UpdateFlightPrice(UserInputs userInputs);
        string DeleteFlightsRecord(UserInputs userInputs);
    }
}
