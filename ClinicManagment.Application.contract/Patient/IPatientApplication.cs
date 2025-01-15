
using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Patient
{
    public interface IPatientApplication
    {
        OperationResult<PatientViewModel> Create(CreatePatient command);
        OperationResult<PatientViewModel> Edit(EditPatient command);
        OperationResult<PatientViewModel> Remove(int id);
        PatientViewModel GetBy(int id);
        OperationResult<PatientViewModel> Restore(int id);
        List<PatientViewModel> Lists();
        List<PatientViewModel> Search(PatientSearchModel searchModel);
        List<PatientViewModel> PatientReport(PatientReportSearchModel searchModel);
        OperationResult<byte[]> PatientReportExcel(PatientReportSearchModel searchModel);
        List<PatientViewModel> PatientReportBasedOfReferralCount(PatientReportBasedOfReferralCountSearchModel searchModel);
        OperationResult<byte[]> PatientReportBasedOfReferralCountExcel(PatientReportBasedOfReferralCountSearchModel searchModel);
        OperationResult<byte[]> PatientExcelList(PatientSearchModel searchModel);
    
    }
}
