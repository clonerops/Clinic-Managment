using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Referral
{
    public interface IReferralApplication
    {
        OperationResult<ReferralViewModel> Create(CreateReferral command);
        OperationResult<ReferralViewModel> Edit(EditReferral command);
        ReferralViewModel GetBy(long id);
        OperationResult<ReferralViewModel> Remove(long id);
        OperationResult<ReferralViewModel> Restore(long id);
        List<ReferralViewModel> List();
        List<ReferralViewModel> Search(ReferralSearchModel searchModel);


    }
}
