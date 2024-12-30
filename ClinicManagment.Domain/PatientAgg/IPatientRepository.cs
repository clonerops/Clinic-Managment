using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.Patient;

namespace ClinicManagment.Domain.PatientAgg
{
    public interface IPatientRepository : IRepository<int, Patient>
    {
        List<PatientViewModel> List();
        PatientViewModel GetBy(int id);
        List<PatientViewModel> Search(PatientSearchModel searchModel);
        List<PatientViewModel> PatientReport(PatientReportSearchModel searchModel);
        
        
    }
}
