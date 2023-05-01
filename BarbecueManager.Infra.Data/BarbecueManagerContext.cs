using BarbecueManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarbecueManager.Infra.Data
{
    public class BarbecueManagerContext : DbContext
    {

        public BarbecueManagerContext() { }
        public BarbecueManagerContext(DbContextOptions<BarbecueManagerContext> options) : base(options) { }
        public DbSet<Person> Persons{ get; set; }
        public DbSet<Barbecue> Barbecues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure mvarchar to varchar
            foreach (var property in modelBuilder
               .Model
               .GetEntityTypes()
               .SelectMany(
                  e => e.GetProperties()
                     .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(200)");
            }

            // Configure Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BarbecueManagerContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
