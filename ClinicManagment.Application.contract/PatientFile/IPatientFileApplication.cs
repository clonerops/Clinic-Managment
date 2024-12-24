using _0_Framework.Application;

namespace ClinicManagment.Application.contract.PatientFile
{
    public interface IPatientFileApplication
    {
        OperationResult Create(CreatePatientFile command);
        OperationResult Edit(EditPatientFile command);
        OperationResult Remove(int patientId, int documentId, int doctorId);
        OperationResult Restore(int patientId, int documentId, int doctorId);
        List<PatientFileViewModel> List();
        PatientFileViewModel GetBy(long id);
        List<PatientFileViewModel> Search(PatientFileSearchModel searchModel);

    }
}
