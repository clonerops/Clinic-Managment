using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract;

namespace ClinicManagment.Domain.DoctorAgg
{
    public interface IDoctorRepository : IRepository<int, Doctor>
    {
        List<DoctorViewModel> List();
        List<DoctorViewModel> Search(DoctorSearchModel searchModel);
        DoctorViewModel GetBy(int id);
     }
}
