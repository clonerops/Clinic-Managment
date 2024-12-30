using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract;
using ClinicManagment.Domain.DoctorAgg;

namespace ClinicManagment.Infrastructure.EfCore.Repository
{
    public class DoctorRepository : RepositoryBase<int, Doctor>, IDoctorRepository
    {
        private readonly CMContext _context;

        public DoctorRepository(CMContext context) : base(context)
        {
            _context = context;
        }

        public DoctorViewModel GetBy(int id)
        {
            return _context.Doctors.Select(x => new DoctorViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                Description = x.Description,
                Id = x.Id,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<DoctorViewModel> List()
        {
            return _context.Doctors.Where(x => x.IsDeleted == false).Select(x => new DoctorViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }

        public List<DoctorViewModel> Search(DoctorSearchModel searchModel)
        {
            var query = _context.Doctors.Where(x => x.IsDeleted == false).Select(x => new DoctorViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Mobile = x.Mobile,
                Description = x.Description,
                Id = x.Id
            });

            if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
                query = query.Where(x => x.FirstName == searchModel.FirstName);
            if (!string.IsNullOrWhiteSpace(searchModel.LastName))
                query = query.Where(x => x.LastName == searchModel.LastName);
            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile == searchModel.Mobile);
            if (!string.IsNullOrWhiteSpace(searchModel.NationalCode))
                query = query.Where(x => x.NationalCode == searchModel.NationalCode);

            return query.ToList();
        }
    }
}
