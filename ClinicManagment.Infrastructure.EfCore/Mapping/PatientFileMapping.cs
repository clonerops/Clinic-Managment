using ClinicManagment.Domain.PatientFileAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PatientManagment.Infrastructure.EfCore.Mapping
{
    public class PatientFileMapping : IEntityTypeConfiguration<PatientFile>
    {
        public void Configure(EntityTypeBuilder<PatientFile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PatientId).IsRequired();
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.FileCode).IsRequired();

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.PatientFiles)
                .HasForeignKey(x => x.PatientId);

            builder.HasOne(x => x.Document)
                .WithMany(x => x.PatientFiles)
                .HasForeignKey(x => x.DocumentId);

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.PatientFiles)
                .HasForeignKey(x => x.DoctorId);

            builder.HasMany(x => x.Referrals)
                .WithOne(x => x.PatientFile)
                .HasForeignKey(x => x.PatientFileId);

        }   
    }
}
