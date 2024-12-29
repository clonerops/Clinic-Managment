using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Referral
{
    public interface IReferralApplication
    {
        OperationResult Create(CreateReferral command);
        OperationResult Edit(EditReferral command);
        ReferralViewModel GetBy(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<ReferralViewModel> List();
        List<ReferralViewModel> Search(ReferralSearchModel searchModel);


    }
}
