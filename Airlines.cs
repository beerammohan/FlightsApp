using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightsWebApp.Models
{
    public class Airlines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirlinesId { get; set; }
        public string AirlinesName { get; set; }
    }
}
