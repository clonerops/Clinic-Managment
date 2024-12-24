using _0_Framework.Infrastructure;
using AccountManagment.Application.contract.Account;

namespace AccountManagment.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<Guid, Account>
    {
        List<AccountViewModel> List();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
