using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountMS.Domain.Entities;

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
            builder.Property(s => s.Description).HasMaxLength(150);
        }
    }
}
