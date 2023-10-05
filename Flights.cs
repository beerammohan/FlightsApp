using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightsWebApp.Models
{
    public class Flights
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightsId { get; set; }
        public string Source { get; set;}
        public string Destination { get; set;}
        [ForeignKey("AirlinesId")]
        public int AirlinesId { get; set; }
        public DateTime D_Date { get; set;}
        public string D_Time { get; set;}
        public DateTime A_Date { get; set;}
        public string A_Time { get; set;}
        public decimal Price { get; set;}
    }
}
