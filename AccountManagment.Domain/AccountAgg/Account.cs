using _0_Framework.Domain;

namespace AccountManagment.Domain.AccountAgg
{
    public class Account : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }

        public Account(string firstName, string lastName, string userName, 
            string password, string mobile, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            NationalCode = nationalCode;
        }

        public void Edit(string firstName, string lastName, string userName,
             string mobile, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Mobile = mobile;
            NationalCode = nationalCode;
        }

        public void Removed()
        {
            IsDeleted = true;
        }

        public void Restored()
        {
            IsDeleted = false;
        }
    }
}
