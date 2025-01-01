using _0_Framework.Application;

namespace AccountManagment.Application.contract.Account
{
    public interface IAccountApplication
    {
        OperationResult<AccountViewModel> Create(CreateAccount command);
        OperationResult<AccountViewModel> Edit(EditAccount command);
        OperationResult<AccountViewModel> Remove(Guid id);
        OperationResult<AccountViewModel> Restore(Guid id);
        List<AccountViewModel> List();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        AuthResult Login(Login command);

    }
}
