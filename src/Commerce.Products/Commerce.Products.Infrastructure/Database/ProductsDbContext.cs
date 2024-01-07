using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Commerce.Products.Infrastructure.Database
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        // Polimorfismo para alterar o comportamento do método OnModelCreating.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Obtém as configurações das entidades do Entity Framework automáticamente a partir do assembly em execução.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
