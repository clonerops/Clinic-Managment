using _0_Framework.Application;

namespace AccountManagment.Application.contract.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult Remove(Guid id);
        OperationResult Restore(Guid id);
        List<AccountViewModel> List();
        List<AccountViewModel> Search(AccountSearchModel searchModel);

    }
}
