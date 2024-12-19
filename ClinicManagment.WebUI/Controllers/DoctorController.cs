using ClinicManagment.Application.contract;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorApplication _DoctorApplication;

        public DoctorController(IDoctorApplication DoctorApplication)
        {
            _DoctorApplication = DoctorApplication;
        }

        [HttpPost]
        public JsonResult CreateDoctor(CreateDoctor command)
        {
            var Doctor = _DoctorApplication.Create(command);
            return new JsonResult(Doctor);
        }

        [HttpPut("{id:int}")]
        public JsonResult EditDoctor([FromBody] EditDoctor command)
        {
            var Doctor = _DoctorApplication.Edit(command);
            return new JsonResult(Doctor);
        }

        [HttpGet]
        public JsonResult GetAllDoctors()
        {
            var Doctor = _DoctorApplication.List();
            return new JsonResult(Doctor);
        }

        [HttpGet("{id:int}")]
        public JsonResult GetDoctorById(int id)
        {
            var Doctor = _DoctorApplication.GetBy(id);
            return new JsonResult(Doctor);
        }

        [HttpDelete("{id:int}")]
        public JsonResult DeleteAccount([FromRoute] int id)
        {
            var account = _DoctorApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:int}")]
        public JsonResult RestoreAccount([FromRoute] int id)
        {
            var account = _DoctorApplication.Restore(id);

            return new JsonResult(account);
        }
    }
}
