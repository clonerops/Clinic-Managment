using _0_Framework.Application;
using ClinicManagment.Application.contract.Document;
using ClinicManagment.Domain.DocumentAgg;

namespace ClinicManagment.Application
{
    public class DocumentApplication : IDocumentApplication
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentApplication(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public OperationResult Create(CreateDocument command)
        {
            var operation = new OperationResult();

            if (_documentRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("اطلاعات نوع پرونده قبلا در سامانه ایجاد شده است");

            var document = new Document(command.Name, command.Description);
            _documentRepository.Create(document);
            _documentRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditDocument command)
        {
            var operation = new OperationResult();
            
            var document = _documentRepository.Get(command.Id);

            if (document == null)
                return operation.Failed("اطلاعات مربوط به پرونده یافت نشد");

            document.Edit(command.Name, command.Description);
            _documentRepository.SaveChanges();
            return operation.Succedded();

        }

        public DocumentViewModel GetBy(int id)
        {
            return _documentRepository.GetBy(id);
        }

        public List<DocumentViewModel> List()
        {
            return _documentRepository.List();
        }

        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();

            var document = _documentRepository.Get(id);

            if (document == null)
                return operation.Failed("اطلاعات مربوط به پرونده یافت نشد");

            document.Removed();
            _documentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();

            var document = _documentRepository.Get(id);

            if (document == null)
                return operation.Failed("اطلاعات مربوط به پرونده یافت نشد");

            document.Restore();
            _documentRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<DocumentViewModel> Search(DocumentSearchModel searchModel)
        {
            return _documentRepository.Search(searchModel);
        }
    }
}
