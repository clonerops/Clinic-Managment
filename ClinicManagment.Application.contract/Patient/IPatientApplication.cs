
using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Patient
{
    public interface IPatientApplication
    {
        OperationResult Create(CreatePatient command);
        OperationResult Edit(EditPatient command);
        OperationResult Remove(int id);
        PatientViewModel GetBy(int id);
        OperationResult Restore(int id);
        List<PatientViewModel> Lists();
        List<PatientViewModel> Search(PatientSearchModel searchModel);
    }
}
