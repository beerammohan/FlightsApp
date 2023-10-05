namespace FlightsWebApp.Repository
{
    public class FlightDetailsDTO
    {
        public int AirlinesId { get; set; }
        public string AirlinesName { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public decimal Price { get; set;}
    
    }
}
