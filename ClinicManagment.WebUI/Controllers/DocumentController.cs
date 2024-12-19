using ClinicManagment.Application.contract.Document;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentApplication _DocumentApplication;

        public DocumentController(IDocumentApplication DocumentApplication)
        {
            _DocumentApplication = DocumentApplication;
        }

        [HttpPost]
        public JsonResult CreateDocument(CreateDocument command)
        {
            var Document = _DocumentApplication.Create(command);
            return new JsonResult(Document);
        }

        [HttpPut("{id:int}")]
        public JsonResult EditDocument([FromBody] EditDocument command)
        {
            var Document = _DocumentApplication.Edit(command);
            return new JsonResult(Document);
        }

        [HttpGet]
        public JsonResult GetAllDocuments()
        {
            var Document = _DocumentApplication.List();
            return new JsonResult(Document);
        }

        [HttpGet("{id:int}")]
        public JsonResult GetDocumentById(int id)
        {
            var Document = _DocumentApplication.GetBy(id);
            return new JsonResult(Document);
        }

        [HttpDelete("{id:int}")]
        public JsonResult DeleteAccount([FromRoute] int id)
        {
            var account = _DocumentApplication.Remove(id);

            return new JsonResult(account);
        }

        [HttpPut("Restore/{id:int}")]
        public JsonResult RestoreAccount([FromRoute] int id)
        {
            var account = _DocumentApplication.Restore(id);

            return new JsonResult(account);
        }
    }
}
