using AccountMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMS.Infrastructure.Database.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.ClientId).IsRequired();
            builder.Property(s => s.AccountNumber).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Balance).HasDefaultValue(0);
            builder.Property(s => s.Currency).IsRequired().HasMaxLength(2);
            builder
                .Property(s => s.AccountType)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();
        }
    }
}
