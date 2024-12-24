using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Referral
{
    public interface IReferralApplication
    {
        OperationResult Create(CreateReferral command);
        OperationResult Edit(EditReferral command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<ReferralViewModel> List();


    }
}
