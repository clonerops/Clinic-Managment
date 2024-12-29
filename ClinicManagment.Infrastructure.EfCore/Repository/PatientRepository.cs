using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.Patient;
using ClinicManagment.Domain.PatientAgg;

namespace ClinicManagment.Infrastructure.EfCore.Repository
{
    public class PatientRepository: RepositoryBase<int, Patient>, IPatientRepository
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
    }
}
