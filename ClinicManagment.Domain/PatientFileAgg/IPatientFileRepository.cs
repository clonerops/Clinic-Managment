using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.PatientFile;
using System.Linq.Expressions;

namespace ClinicManagment.Domain.PatientFileAgg
{
    public interface IPatientFileRepository : IRepository<long, PatientFile>
    {
        List<PatientFileViewModel> List();
        List<PatientFile> ListPatientFile();
        PatientFileViewModel GetBy(long id);
        PatientFileViewModel GetBy(Expression<Func<PatientFile, PatientFileViewModel>> expression);
        List<PatientFileViewModel> Search(PatientFileSearchModel searchModel);

    }
}
