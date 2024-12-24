using AccountManagment.Domain.AccountAgg;
using AccountManagment.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagment.Infrastructure.EfCore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
