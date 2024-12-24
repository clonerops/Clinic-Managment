using ClinicManagment.Application.contract;
using ClinicManagment.Application.contract.Referral;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagment.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralApplication _ReferralApplication;

        public ReferralController(IReferralApplication ReferralApplication)
        {
            _ReferralApplication = ReferralApplication;
        }

        [HttpPost]
        public JsonResult CreateReferral(CreateReferral command)
        {
            var Referral = _ReferralApplication.Create(command);
            return new JsonResult(Referral);
        }

        [HttpPut("{id:long}")]
        public JsonResult EditReferral([FromBody] EditReferral command)
        {
            var Referral = _ReferralApplication.Edit(command);
            return new JsonResult(Referral);
        }

        [HttpGet]
        public JsonResult GetAllReferrals()
        {
            var Referral = _ReferralApplication.List();
            return new JsonResult(Referral);
        }


        [HttpDelete("{id:long}")]
        public JsonResult DeleteAccount([FromRoute] long id)
        {
            var account = _ReferralApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:long}")]
        public JsonResult RestoreAccount([FromRoute] long id)
        {
            var account = _ReferralApplication.Restore(id);

            return new JsonResult(account);
        }
    }
}
