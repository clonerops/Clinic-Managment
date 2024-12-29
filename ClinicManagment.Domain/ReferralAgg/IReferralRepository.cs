using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.Referral;

namespace ClinicManagment.Domain.ReferralAgg
{
    public interface IReferralRepository : IRepository<long, Referral>
    {
        List<ReferralViewModel> List();
        List<ReferralViewModel> Search(ReferralSearchModel searchModel);
        ReferralViewModel GetBy(long id);
    }
}
