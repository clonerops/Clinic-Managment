using _0_Framework.Infrastructure;

namespace AccountManagment.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<Guid, Account>
    {
    }
}
