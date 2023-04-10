using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Persistence.EntityConfigurations
{
    public class MoneyTransactionEntityTypeConfiguration : IEntityTypeConfiguration<MoneyTransaction>
    {
        public void Configure(EntityTypeBuilder<MoneyTransaction> builder)
        {
            builder.ToTable("MoneyTransactions");

            builder.HasOne(t => t.AuthorizedUser)
                .WithMany()
                .HasForeignKey(t=>t.UserId);
        }
    }
}
