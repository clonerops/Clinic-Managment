﻿namespace AccountManagment.Application.contract.Account
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
    }
}