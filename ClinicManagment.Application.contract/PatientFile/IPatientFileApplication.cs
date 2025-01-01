using _0_Framework.Application;

namespace ClinicManagment.Application.contract.PatientFile
{
    public interface IPatientFileApplication
    {
        OperationResult<PatientFileViewModel> Create(CreatePatientFile command);
        OperationResult<PatientFileViewModel> Edit(EditPatientFile command);
        OperationResult<PatientFileViewModel> Remove(int patientId, int documentId, int doctorId);
        OperationResult<PatientFileViewModel> Restore(int patientId, int documentId, int doctorId);
        List<PatientFileViewModel> List();
        PatientFileViewModel GetBy(long id);
        List<PatientFileViewModel> Search(PatientFileSearchModel searchModel);

    }
}
