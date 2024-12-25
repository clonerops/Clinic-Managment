using AccountManagment.Application;
using AccountManagment.Application.contract.Account;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagment.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountApplication _AccountApplication;

        public AccountController(IAccountApplication AccountApplication)
        {
            _AccountApplication = AccountApplication;
        }

        [HttpPost]
        public JsonResult CreateAccount(CreateAccount command)
        {
            var Account = _AccountApplication.Create(command);
            return new JsonResult(Account);
        }

        [HttpPut("{id:int}")]
        public JsonResult EditAccount([FromBody] EditAccount command)
        {
            var Account = _AccountApplication.Edit(command);
            return new JsonResult(Account);
        }

        [HttpGet]
        public JsonResult GetAllAccounts()
        {
            var Account = _AccountApplication.List();
            return new JsonResult(Account);
        }

        [HttpDelete("{id:Guid}")]
        public JsonResult DeleteAccount([FromRoute] Guid id)
        {
            var account = _AccountApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:Guid}")]
        public JsonResult RestoreAccount([FromRoute] Guid id)
        {
            var account = _AccountApplication.Restore(id);

            return new JsonResult(account);
        }

        [HttpPost("Login")]
        public JsonResult Login(Login command)
        {
            var account = _AccountApplication.Login(command);

            return new JsonResult(account);
        }

    }
}
