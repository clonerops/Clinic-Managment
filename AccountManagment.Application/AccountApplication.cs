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

        public OperationResult<AccountViewModel> Create(CreateAccount command)
        {
            var opeartion = new OperationResult<AccountViewModel>();

            if (_accountRepository.Exist(x => x.UserName == command.UserName))
                return opeartion.Failed("کاربر بااین نام کاربری قبلا در سامانه ثبت شده است");

            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.FirstName, command.LastName, command.UserName, password,
                command.Mobile, command.NationalCode);

            _accountRepository.Create(account);

            _accountRepository.SaveChanges();

            var accountViewModel = new AccountViewModel
            {
                Id = account.Id,
            };

            return opeartion.Succedded(accountViewModel);

        }

        public OperationResult<AccountViewModel> Edit(EditAccount command)
        {
            var operation = new OperationResult<AccountViewModel>();

            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed("اکانتی با این مشخصات یافت نشد.");

            account.Edit(command.FirstName, command.LastName,
                command.UserName, command.Mobile, command.NationalCode);
              
            _accountRepository.SaveChanges();

            var accountViewModel = new AccountViewModel
            {
                Id = account.Id,
            };

            return operation.Succedded(accountViewModel);

        }

        public List<AccountViewModel> List()
        {
            return _accountRepository.List();
        }

        public OperationResult<AccountViewModel> Remove(Guid id)
        {
            var operation = new OperationResult<AccountViewModel>();

            var account = _accountRepository.Get(id);
            if (account == null)
                return operation.Failed("اکانتی با این مشخصات یافت نشد.");

            account.Removed();
            _accountRepository.SaveChanges();

            var accountViewModel = new AccountViewModel
            {
                Id = account.Id,
            };

            return operation.Succedded(accountViewModel);
        }

        public OperationResult<AccountViewModel> Restore(Guid id)
        {
            var operation = new OperationResult<AccountViewModel>();

            var account = _accountRepository.Get(id);
            if (account == null)
                return operation.Failed("اکانتی با این مشخصات یافت نشد.");

            account.Restored();
            _accountRepository.SaveChanges();

            var accountViewModel = new AccountViewModel
            {
                Id = account.Id,
            };

            return operation.Succedded(accountViewModel);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public AuthResult Login(Login command)
        {
            var operation = new AuthResult();

            var account = _accountRepository.GetByUserName(command.UserName);
            if (account == null)
                return operation.Failed("کاربر با این مشخصات وجود ندارد");

            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);

            if(!result.Verified)
                return operation.Failed("کاربر با این مشخصات وجود ندارد");

            var token = _tokenServices.GenerateToken(new AuthViewModel
            {
                UserName = command.UserName,
            });

            return operation.Succedded(token);
        }


    }
}
