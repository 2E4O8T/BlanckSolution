using Microsoft.EntityFrameworkCore;
using Movies.Api.Model;

namespace Movies.Api.Data
{
    public class MoviesApiContext : DbContext
    {
        public MoviesApiContext(DbContextOptions<MoviesApiContext> options) : base(options) 
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
