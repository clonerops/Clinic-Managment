using AccountManagment.Application;
using AccountManagment.Application.contract.Account;
using AccountManagment.Domain.AccountAgg;
using AccountManagment.Infrastructure.EfCore;
using AccountManagment.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagment.Infrastructure.Configuration
{
    public class AccountManagmentBoostrapper
    {
        public void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
