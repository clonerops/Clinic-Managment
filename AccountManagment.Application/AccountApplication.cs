using _0_Framework.Application;
using AccountManagment.Application.contract.Account;

namespace AccountManagment.Application
{
    public class AccountApplication : IAccountApplication
    {
        public OperationResult Create(CreateAccount command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditAccount command)
        {
            throw new NotImplementedException();
        }

        public List<AccountViewModel> List()
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Restore(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
