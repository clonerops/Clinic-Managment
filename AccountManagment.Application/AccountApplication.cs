using _0_Framework.Application;
using AccountManagment.Application.contract.Account;
using AccountManagment.Domain.AccountAgg;

namespace AccountManagment.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenServices _tokenServices;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            ITokenServices tokenServices)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _tokenServices = tokenServices;

        }

        public OperationResult Create(CreateAccount command)
        {
            var opeartion = new OperationResult();

            if (_accountRepository.Exist(x => x.UserName == command.UserName))
                return opeartion.Failed("کاربر بااین نام کاربری قبلا در سامانه ثبت شده است");

            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.FirstName, command.LastName, command.UserName, password,
                command.Mobile, command.NationalCode);

            _accountRepository.Create(account);

            _accountRepository.SaveChanges();

            return opeartion.Succedded();

        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed("اکانتی با این مشخصات یافت نشد.");

            account.Edit(command.FirstName, command.LastName,
                command.UserName, command.Mobile, command.NationalCode);
              
            _accountRepository.SaveChanges();

            return operation.Succedded();

        }

        public List<AccountViewModel> List()
        {
            return _accountRepository.List();
        }

        public OperationResult Remove(Guid id)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(id);
            if (account == null)
                return operation.Failed("اکانتی با این مشخصات یافت نشد.");

            account.Removed();
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Restore(Guid id)
        {
            var operation = new OperationResult();

            var account = _accountRepository.Get(id);
            if (account == null)
                return operation.Failed("اکانتی با این مشخصات یافت نشد.");

            account.Restored();
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

    }
}
