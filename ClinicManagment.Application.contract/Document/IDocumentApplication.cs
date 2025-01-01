using _0_Framework.Application;

namespace ClinicManagment.Application.contract.Document
{
    public interface IDocumentApplication
    {
        OperationResult<DocumentViewModel> Create(CreateDocument command);
        OperationResult<DocumentViewModel> Edit(EditDocument command);
        OperationResult<DocumentViewModel> Remove(int id);
        OperationResult<DocumentViewModel> Restore(int id);
        DocumentViewModel GetBy(int id);
        List<DocumentViewModel> List();
        List<DocumentViewModel> Search(DocumentSearchModel searchModel);

    }
}
