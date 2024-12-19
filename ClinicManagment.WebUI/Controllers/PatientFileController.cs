using ClinicManagment.Application.contract.PatientFile;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagment.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFileController : ControllerBase
    {
        private readonly IPatientFileApplication _patientFileApplication;

        public PatientFileController(IPatientFileApplication PatientFileApplication)
        {
            _patientFileApplication = PatientFileApplication;
        }

        [HttpPost]
        public JsonResult CreatePatientFIle(CreatePatientFile command)
        {
            var PatientFIle = _patientFileApplication.Create(command);
            return new JsonResult(PatientFIle);
        }

        [HttpPut("{id:int}")]
        public JsonResult EditPatientFIle([FromBody] EditPatientFile command)
        {
            var PatientFIle = _patientFileApplication.Edit(command);
            return new JsonResult(PatientFIle);
        }

        [HttpGet]
        public JsonResult GetAllPatientFIles()
        {
            var PatientFIle = _patientFileApplication.List();
            return new JsonResult(PatientFIle);
        }

        [HttpGet("{id:int}")]
        public JsonResult GetPatientFIleById(int id)
        {
            var PatientFIle = _patientFileApplication.GetBy(id);
            return new JsonResult(PatientFIle);
        }

        [HttpDelete("{id:int}")]
        public JsonResult DeleteAccount([FromRoute] int id)
        {
            var account = _patientFileApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:int}")]
        public JsonResult RestoreAccount([FromRoute] int id)
        {
            var account = _patientFileApplication.Restore(id);

            return new JsonResult(account);
        }
    }
}
