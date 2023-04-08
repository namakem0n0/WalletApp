using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Persistence.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasOne(u => u.Card)
                .WithOne();
            builder.HasMany(u => u.MoneyTransactions)
                .WithOne();
        }
    }
}
