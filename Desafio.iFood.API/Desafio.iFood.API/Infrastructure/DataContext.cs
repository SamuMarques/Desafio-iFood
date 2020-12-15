using Desafio.iFood.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Desafio.iFood.API.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
