﻿using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.PatientFile;
using ClinicManagment.Application.contract.Referral;
using ClinicManagment.Domain.ReferralAgg;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagment.Infrastructure.EfCore.Repository
{
    public class ReferralRepository : RepositoryBase<long, Referral>, IReferralRepository
    {
        private readonly CMContext _context;
        public ReferralRepository(CMContext context) : base(context)
        {
            _context = context;
        }

        public List<ReferralViewModel> List()
        {
            return _context.Referrals.Include(x => x.PatientFile).Where(x => x.IsDeleted == false).Select(x => new ReferralViewModel
            {
                Id = x.Id,
                PatientFile = new PatientFileViewModel
                {
                    Id = x.PatientFile.Id,
                    DoctorId = x.PatientFile.DoctorId,
                    DoctorName = x.PatientFile.Doctor.FirstName + " " + x.PatientFile.Doctor.LastName,
                    DocumentId = x.PatientFile.DocumentId,
                    DocumentName = x.PatientFile.Document.Name,
                    FileCode = x.PatientFile.FileCode,
                    PatientId = x.PatientFile.PatientId,
                    PatientName = x.PatientFile.Patient.FirstName + " " + x.PatientFile.Patient.LastName
                },
                ReferralDate = x.ReferralDate,
                ReferralDescription = x.ReferralDescription,
                ReferralReason = x.ReferralReason
            }).ToList();
        }
    }
}
