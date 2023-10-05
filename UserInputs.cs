namespace FlightsWebApp.Models
{
    public class UserInputs
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public int AirlinesId { get; set; }
        
        public decimal Price { get; set; }
    }
}
