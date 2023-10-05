using FlightsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightsWebApp.DBContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Airlines> Airlines { get; set; }
        public DbSet<Flights> Flights { get; set; }
    }
}
