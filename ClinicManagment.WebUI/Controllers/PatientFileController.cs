using ClinicManagment.Application.contract.Patient;
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
        public JsonResult GetAllPatientFIles([FromQuery] PatientFileSearchModel searchModel)
        {
            var PatientFIle = _patientFileApplication.Search(searchModel);
            return new JsonResult(PatientFIle);
        }

        [HttpGet("{id:int}")]
        public JsonResult GetPatientFIleById(int id)
        {
            var PatientFIle = _patientFileApplication.GetBy(id);
            return new JsonResult(PatientFIle);
        }

        [HttpDelete("{id:int}")]
        public JsonResult DeleteAccount(int patientId, int documentId,int doctorId)
        {
            var account = _patientFileApplication.Remove(patientId, documentId, doctorId);

            return new JsonResult(account);
        }

        [HttpPut("Restore")]
        public JsonResult RestoreAccount(int patientId, int documentId, int doctorId)
        {
            var account = _patientFileApplication.Restore(patientId, documentId, doctorId);

            return new JsonResult(account);
        }
    }
}
