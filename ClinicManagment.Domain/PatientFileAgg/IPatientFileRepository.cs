using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.PatientFile;

namespace ClinicManagment.Domain.PatientFileAgg
{
    public interface IPatientFileRepository : IRepository<long, PatientFile>
    {
        List<PatientFileViewModel> List();
        PatientFileViewModel GetBy(long id);
        List<PatientFileViewModel> Search(PatientFileSearchModel searchModel);

    }
}
