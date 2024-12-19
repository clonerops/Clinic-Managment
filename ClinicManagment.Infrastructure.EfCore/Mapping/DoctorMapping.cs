using ClinicManagment.Domain.DoctorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagment.Infrastructure.EfCore.Mapping
{
    public class DoctorMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(x => x.NationalCode).HasMaxLength(10);

            builder.HasMany(x => x.PatientFiles)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
