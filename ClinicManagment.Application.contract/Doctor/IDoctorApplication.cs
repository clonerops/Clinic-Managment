using _0_Framework.Application;

namespace ClinicManagment.Application.contract
{
    public interface IDoctorApplication
    {
        OperationResult Create(CreateDoctor command);
        OperationResult Edit(EditDoctor command);
        OperationResult Remove(int id);
        OperationResult Restore(int id);
        DoctorViewModel GetBy(int id);
        List<DoctorViewModel> List();
        List<DoctorViewModel> Search(DoctorSearchModel searchModel);
        
        

    }
}
