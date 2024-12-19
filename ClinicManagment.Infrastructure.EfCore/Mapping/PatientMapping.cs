using ClinicManagment.Domain.PatientAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagment.Infrastructure.EfCore.Mapping
{
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NationalCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(x => x.WhatsappNumber);
            builder.Property(x => x.HomeNumber);
            builder.Property(x => x.BirthDate);
            builder.Property(x => x.Job);
            builder.Property(x => x.Education);
            builder.Property(x => x.Reagent);
            builder.Property(x => x.Gender);
            builder.Property(x => x.MaritalStatus);
            builder.Property(x => x.Address);
            builder.Property(x => x.Description);

            builder.HasMany(x => x.PatientFiles)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

        }
    }
}
