using ClinicManagment.Domain.PatientAgg;
using Microsoft.EntityFrameworkCore;
using ClinicManagment.Infrastructure.EfCore.Mapping;
using ClinicManagment.Domain.DoctorAgg;
using ClinicManagment.Domain.DocumentAgg;
using ClinicManagment.Domain.PatientFileAgg;
using PatientManagment.Infrastructure.EfCore.Mapping;
using ClinicManagment.Domain.ReferralAgg;

namespace ClinicManagment.Infrastructure.EfCore
{
    public class CMContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<PatientFile> PatientFiles { get; set; }
        public DbSet<Referral> Referrals { get; set; }

        public CMContext(DbContextOptions<CMContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientMapping());
            modelBuilder.ApplyConfiguration(new DoctorMapping());
            modelBuilder.ApplyConfiguration(new DocumentMapping());
            modelBuilder.ApplyConfiguration(new PatientFileMapping());
            modelBuilder.ApplyConfiguration(new ReferralMapping());

            base.OnModelCreating(modelBuilder);
        }


    }
}
