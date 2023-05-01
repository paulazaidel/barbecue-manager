using BarbecueManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarbecueManager.Infra.Data.Mappings
{
    public class BarbecueMapping : IEntityTypeConfiguration<Barbecue>
    {
        public void Configure(EntityTypeBuilder<Barbecue> builder)
        {
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Description)
               .IsRequired();
            
            builder.Property(value => value.Observation)
               .IsRequired();

            builder.Property(value => value.Date)
               .IsRequired();
            
            builder.Property(value => value.ContributionAmountWithDrinks)
               .IsRequired();
            
            builder.Property(value => value.ContributionAmountWithoutDrinks)
               .IsRequired();

            builder.HasMany(value => value.Persons)
               .WithMany(value => value.Barbecues)
               .UsingEntity(value => value.ToTable("PersonBarbecues"));

            builder.ToTable("Barbecues");
        }
    }
}
