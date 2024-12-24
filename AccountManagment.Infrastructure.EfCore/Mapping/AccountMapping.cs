using AccountManagment.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagment.Infrastructure.EfCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
            builder.Property(x => x.NationalCode).HasMaxLength(10);
            builder.Property(x => x.Mobile).HasMaxLength(11);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
        }
    }
}
