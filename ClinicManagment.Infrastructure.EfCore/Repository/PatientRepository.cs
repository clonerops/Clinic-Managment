using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.Patient;
using ClinicManagment.Application.contract.PatientFile;
using ClinicManagment.Application.contract.Referral;
using ClinicManagment.Domain.PatientAgg;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagment.Infrastructure.EfCore.Repository
{
    public class PatientRepository : RepositoryBase<int, Patient>, IPatientRepository
    {
        private readonly CMContext _context;

        public PatientRepository(CMContext context) : base(context)
        {
            _context = context;
        }

        public PatientViewModel GetBy(int id)
        {
            return _context.Patients.Where(x => x.IsDeleted == false).Select(x => new PatientViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                WhatsappNumber = x.WhatsappNumber,
                HomeNumber = x.HomeNumber,
                BirthDate = x.BirthDate,
                Job = x.Job,
                MaritalStatus = x.MaritalStatus,
                Description = x.Description,
                Education = x.Education,
                Gender = x.Gender,
                Reagent = x.Reagent,
                Id = x.Id,
                Address = x.Address,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PatientViewModel> List()
        {
            return _context.Patients.Where(x => x.IsDeleted == false).Select(x => new PatientViewModel
            {
                Code = x.Code,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                WhatsappNumber = x.WhatsappNumber,
                HomeNumber = x.HomeNumber,
                BirthDate = x.BirthDate,
                Job = x.Job,
                MaritalStatus = x.MaritalStatus,
                Description = x.Description,
                Education = x.Education,
                Gender = x.Gender,
                Reagent = x.Reagent,
                Id = x.Id,
                Address = x.Address,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<PatientViewModel> Search(PatientSearchModel searchModel)
        {
            var query = _context.Patients.Where(x => x.IsDeleted == false).Select(x => new PatientViewModel
            {
                Code = x.Code,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                WhatsappNumber = x.WhatsappNumber,
                HomeNumber = x.HomeNumber,
                BirthDate = x.BirthDate,
                Job = x.Job,
                MaritalStatus = x.MaritalStatus,
                Description = x.Description,
                Education = x.Education,
                Gender = x.Gender,
                Reagent = x.Reagent,
                Id = x.Id,
                Address = x.Address,
            });

            if (searchModel.Id > 0)
                query = query.Where(x => x.Id == searchModel.Id);

            if(!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile == searchModel.Mobile);

            if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
                query = query.Where(x => x.FirstName == searchModel.FirstName);

            if (!string.IsNullOrWhiteSpace(searchModel.LastName))
                query = query.Where(x => x.LastName == searchModel.LastName);

            if (!string.IsNullOrWhiteSpace(searchModel.NationalCode))
                query = query.Where(x => x.NationalCode == searchModel.NationalCode);

            return query.ToList();

        }

        public List<PatientViewModel> PatientReport(PatientReportSearchModel searchModel)
        {
            var query = _context.Patients.Include(x => x.PatientFiles).Where(x => x.IsDeleted == false).Select(x => new PatientViewModel
            {
                Code = x.Code,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                WhatsappNumber = x.WhatsappNumber,
                HomeNumber = x.HomeNumber,
                BirthDate = x.BirthDate,
                Job = x.Job,
                MaritalStatus = x.MaritalStatus,
                Description = x.Description,
                Education = x.Education,
                Gender = x.Gender,
                Reagent = x.Reagent,
                Id = x.Id,
                Address = x.Address,
                PatientFiles = x.PatientFiles.Select(x => new PatientFileViewModel
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    FileCode = x.FileCode,  
                    DocumentId = x.DocumentId,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FirstName +" " + x.Doctor.LastName,
                    DocumentName = x.Document.Name,
                    CreationDateGr = x.CreationDate,
                    CreationDate = x.CreationDate.ToFarsi()
                }).ToList(),
            });

            if (searchModel.DocumentId > 0)
                query = query.Where(x => x.PatientFiles.Any(x => x.DocumentId == searchModel.DocumentId));

            if (!string.IsNullOrWhiteSpace(searchModel.FromDate))
            {
                var fromDate = DateTime.Now;
                query = query.Where(x => x.PatientFiles.Any(x => x.CreationDateGr > fromDate));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ToDate))
            {
                var toDate = DateTime.Now;
                query = query.Where(x => x.PatientFiles.Any(x => x.CreationDateGr < toDate));
            }

            return query.ToList();

        }

        public List<PatientViewModel> PatientReportBasedOfReferralCount(PatientReportBasedOfReferralCountSearchModel searchModel)
        {
            var query = _context.Patients.Include(x => x.PatientFiles).ThenInclude(x => x.Referrals).Where(x => x.IsDeleted == false).Select(x => new PatientViewModel
            {
                Code = x.Code,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                WhatsappNumber = x.WhatsappNumber,
                HomeNumber = x.HomeNumber,
                BirthDate = x.BirthDate,
                Job = x.Job,
                MaritalStatus = x.MaritalStatus,
                Description = x.Description,
                Education = x.Education,
                Gender = x.Gender,
                Reagent = x.Reagent,
                Id = x.Id,
                Address = x.Address,
                PatientFiles = x.PatientFiles.Select(x => new PatientFileViewModel
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    FileCode = x.FileCode,
                    DocumentId = x.DocumentId,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    DocumentName = x.Document.Name,
                    CreationDateGr = x.CreationDate,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Referrals = x.Referrals.Select(x => new ReferralViewModel
                    {
                        Id= x.Id,
                        ReferralDate = x.ReferralDate,
                        ReferralDescription = x.ReferralDescription,
                        ReferralReason = x.ReferralReason,
                    }).ToList(),
                }).ToList(),
            });

            if (searchModel.DocumentId > 0)
                query = query.Where(x => x.PatientFiles.Any(x => x.DocumentId == searchModel.DocumentId));
            
            //if (searchModel.FromReferral > 0)
            //    query = query.Where(x => x.PatientFiles.Any(x => x.Referrals.Count >= searchModel.FromReferral));

            //if (searchModel.ToReferral > 0)
            //    query = query.Where(x => x.PatientFiles.Any(x => x.Referrals.Count <= searchModel.ToReferral));

            if (!string.IsNullOrWhiteSpace(searchModel.FromDate))
            {
                var fromDate = DateTime.Now;
                query = query.Where(x => x.PatientFiles.Any(x => x.CreationDateGr > fromDate));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ToDate))
            {
                var toDate = DateTime.Now;
                query = query.Where(x => x.PatientFiles.Any(x => x.CreationDateGr < toDate));
            }

            return query.ToList();

        }
    }
}
