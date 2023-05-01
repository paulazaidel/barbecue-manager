using BarbecueManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarbecueManager.Infra.Data.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Fullname)
               .IsRequired();
            
            builder.Property(value => value.ContributionAmount)
               .IsRequired();

            builder.HasMany(value => value.Barbecues)
               .WithMany(value => value.Persons)
               .UsingEntity(value => value.ToTable("PersonBarbecues"));

            builder.ToTable("Persons");
        }
    }
}
