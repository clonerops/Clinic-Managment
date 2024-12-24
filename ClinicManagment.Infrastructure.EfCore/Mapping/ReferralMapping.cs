using ClinicManagment.Domain.ReferralAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagment.Infrastructure.EfCore.Mapping
{
    public class ReferralMapping : IEntityTypeConfiguration<Referral>
    {
        public void Configure(EntityTypeBuilder<Referral> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReferralDate).HasMaxLength(255);
            builder.Property(x => x.ReferralReason);
            builder.Property(x => x.ReferralDescription);

            builder.HasOne(x => x.PatientFile)
                .WithMany(x => x.Referrals)
                .HasForeignKey(x => x.PatientFileId);
        }
    }
}
