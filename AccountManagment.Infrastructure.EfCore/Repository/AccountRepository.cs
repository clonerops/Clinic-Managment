using _0_Framework.Infrastructure;
using AccountManagment.Application.contract.Account;
using AccountManagment.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagment.Infrastructure.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<Guid, Account>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(DbContext context) : base(context)
        {
            context = _context;
        }

        public List<AccountViewModel> List()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Mobile = x.Mobile,
                NationalCode = x.NationalCode,
                UserName = x.UserName,
            }).ToList();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Mobile = x.Mobile,
                NationalCode = x.NationalCode,
                UserName = x.UserName,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query.Where(x => x.UserName == searchModel.UserName);

            return query.ToList();
        }
    }
}
