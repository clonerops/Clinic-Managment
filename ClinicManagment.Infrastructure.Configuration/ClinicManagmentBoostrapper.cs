using ClinicManagment.Application.contract.Patient;
using ClinicManagment.Application;
using ClinicManagment.Domain.PatientAgg;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ClinicManagment.Infrastructure.EfCore.Repository;
using ClinicManagment.Infrastructure.EfCore;
using ClinicManagment.Application.contract;
using ClinicManagment.Domain.DoctorAgg;
using ClinicManagment.Application.contract.Document;
using ClinicManagment.Domain.DocumentAgg;
using ClinicManagment.Application.contract.PatientFile;
using ClinicManagment.Domain.PatientFileAgg;
using ClinicManagment.Application.contract.Referral;
using ClinicManagment.Domain.ReferralAgg;


namespace ClinicManagment.Infrastructure.Configuration
{
    public class ClinicManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientApplication, PatientApplication>();

            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IDoctorApplication, DoctorApplication>();

            services.AddTransient<IDocumentApplication, DocumentApplication>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();

            services.AddTransient<IPatientFileApplication, PatientFileApplication>();
            services.AddTransient<IPatientFileRepository, PatientFileRepository>();

            services.AddTransient<IReferralApplication, ReferralApplication>();
            services.AddTransient<IReferralRepository, ReferralRepository>();

            services.AddDbContext<CMContext>(x => x.UseSqlServer(connectionString));

        }

    }
}
