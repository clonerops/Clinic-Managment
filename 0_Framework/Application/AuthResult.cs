namespace _0_Framework.Application
{
    public class AuthResult
    {
        public bool IsSuccedded { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }

        public AuthResult()
        {
            IsSuccedded = false;
        }

        public AuthResult Succedded(string accessToken, string message="عملیات با موفقیت انجام شد")
        {
            IsSuccedded= true;
            AccessToken= accessToken;
            Message = message;
            return this;
        }

        public AuthResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }


    }
}
