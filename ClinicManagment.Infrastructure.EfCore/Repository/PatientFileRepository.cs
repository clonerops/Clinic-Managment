using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.PatientFile;
using ClinicManagment.Domain.PatientAgg;
using ClinicManagment.Domain.PatientFileAgg;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq.Expressions;

namespace ClinicManagment.Infrastructure.EfCore.Repository
{
    public class PatientFileRepository : RepositoryBase<long, PatientFile>, IPatientFileRepository
    {
        private readonly CMContext _context;

        public PatientFileRepository(CMContext context) : base(context) 
        {
            _context = context;
        }

        public PatientFileViewModel GetBy(long id)
        {
            return _context.PatientFiles
                .Include(x => x.Patient)
                .Include(x => x.Document)
                .Include(x => x.Doctor)
                .Select(x => new PatientFileViewModel
            {
                Id = x.Id,
                PatientId = x.Patient.Id,
                PatientName = String.Concat(x.Patient.FirstName + " " + x.Patient.LastName),
                DocumentId = x.Document.Id,
                DocumentName = x.Document.Name,
                DoctorId = x.Doctor.Id,
                DoctorName = String.Concat(x.Doctor.FirstName + " " + x.Doctor.LastName),
                FileCode = x.FileCode,
                }).FirstOrDefault(x => x.Id == id);
        }

        public PatientFileViewModel GetBy(Expression<Func<PatientFile, PatientFileViewModel>> expression)
        {
            throw new NotImplementedException();
        }

        public List<PatientFileViewModel> List()
        {
            return _context.PatientFiles
                .Include(x => x.Patient)
                .Include(x => x.Document)
                .Include(x => x.Doctor)
                .Select(x => new PatientFileViewModel
                {
                    Id = x.Id,
                    PatientId = x.Patient.Id,
                    PatientName = String.Concat(x.Patient.FirstName + " " + x.Patient.LastName),
                    DocumentId = x.Document.Id,
                    DocumentName = x.Document.Name,
                    DoctorId = x.Doctor.Id,
                    DoctorName = String.Concat(x.Doctor.FirstName + " " + x.Doctor.LastName),
                    FileCode = x.FileCode,
                }).OrderByDescending(x => x.Id).ToList();
        }

        public List<PatientFile> ListPatientFile()
        {
            return _context.PatientFiles
                .Include(x => x.Patient)
                .Include(x => x.Document)
                .Include(x => x.Doctor)
                .ToList();

        }

        public List<PatientFileViewModel> Search(PatientFileSearchModel searchModel)
        {
            var query = _context.PatientFiles
                .Include(x => x.Patient)
                .Include(x => x.Document)
                .Include(x => x.Doctor)
                .Select(x => new PatientFileViewModel
                {
                    Id = x.Id,
                    PatientId = x.Patient.Id,
                    PatientName = String.Concat(x.Patient.FirstName + " " + x.Patient.LastName),
                    FirstName = x.Patient.FirstName,
                    LastName = x.Patient.LastName,
                    Mobile = x.Patient.Mobile,
                    DocumentId = x.Document.Id,
                    DocumentName = x.Document.Name,
                    DoctorId = x.Doctor.Id,
                    DoctorName = String.Concat(x.Doctor.FirstName + " " + x.Doctor.LastName),
                    FileCode = x.FileCode,
                });

            if (searchModel.FileCode > 0)
                query.Where(x => x.FileCode == searchModel.FileCode);

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
                query = query.Where(x => x.FirstName.Contains(searchModel.FirstName));

            if (!string.IsNullOrWhiteSpace(searchModel.LastName))
                query = query.Where(x => x.LastName.Contains(searchModel.LastName));


            return query.ToList();
        }
    }
}
