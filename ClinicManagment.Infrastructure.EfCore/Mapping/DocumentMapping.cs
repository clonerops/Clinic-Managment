using ClinicManagment.Domain.DocumentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagment.Infrastructure.EfCore.Mapping
{
    public class DocumentMapping : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.PatientFiles)
                .WithOne(x => x.Document)
                .HasForeignKey(x => x.DocumentId);
        }
    }
}
