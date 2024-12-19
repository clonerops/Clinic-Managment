using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Document
{
    public interface IDocumentApplication
    {
        OperationResult Create(CreateDocument command);
        OperationResult Edit(EditDocument command);
        OperationResult Remove(int id);
        OperationResult Restore(int id);
        DocumentViewModel GetBy(int id);
        List<DocumentViewModel> List();
        List<DocumentViewModel> Search(DocumentSearchModel searchModel);

    }
}
