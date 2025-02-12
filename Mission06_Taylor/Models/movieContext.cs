using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Taylor.Models
{
    public class movieContext : DbContext
    {
        public movieContext(DbContextOptions<movieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }

}