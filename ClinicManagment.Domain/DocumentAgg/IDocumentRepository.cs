using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.Document;

namespace ClinicManagment.Domain.DocumentAgg
{
    public interface IDocumentRepository : IRepository<int, Document>
    {
        List<DocumentViewModel> List();
        DocumentViewModel GetBy(int id);
        List<DocumentViewModel> Search(DocumentSearchModel searchModel);

    }
}
