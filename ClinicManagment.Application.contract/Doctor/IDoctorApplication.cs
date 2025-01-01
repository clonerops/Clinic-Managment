using _0_Framework.Application;

namespace ClinicManagment.Application.contract
{
    public interface IDoctorApplication
    {
        OperationResult<DoctorViewModel> Create(CreateDoctor command);
        OperationResult<DoctorViewModel> Edit(EditDoctor command);
        OperationResult<DoctorViewModel> Remove(int id);
        OperationResult<DoctorViewModel> Restore(int id);
        DoctorViewModel GetBy(int id);
        List<DoctorViewModel> List();
        List<DoctorViewModel> Search(DoctorSearchModel searchModel);
        
        

    }
}
