using _0_Framework.Application;

namespace ClinicManagment.Application.contract.PatientFile
{
    public interface IPatientFileApplication
    {
        OperationResult Create(CreatePatientFile command);
        OperationResult Edit(EditPatientFile command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<PatientFileViewModel> List();
        PatientFileViewModel GetBy(long id);
        List<PatientFileViewModel> Search(PatientFileSearchModel searchModel);

    }
}
