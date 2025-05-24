using _0_Framework.Infrastructure;
using ClinicManagment.Application.contract.Document;
using ClinicManagment.Domain.DocumentAgg;

namespace ClinicManagment.Infrastructure.EfCore.Repository
{
    public class DocumentRepository : RepositoryBase<int, Document>, IDocumentRepository
    {
        private readonly CMContext _context;

        public DocumentRepository(CMContext context) : base(context)
        {
            _context = context;
        }

        public DocumentViewModel GetBy(int id)
        {
            return _context.Documents.Where(x => x.IsDeleted == false && x.Id == id).Select(x => new DocumentViewModel
            {
                Id = id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefault();
        }

        public List<DocumentViewModel> List()
        {
            return _context.Documents.Where(x => x.IsDeleted == false).Select(x => new DocumentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public List<DocumentViewModel> Search(DocumentSearchModel searchModel)
        {
            var query = _context.Documents.Where(x => x.IsDeleted == false).Select(x => new DocumentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            if (searchModel.Id > 0)
                query.Where(x => x.Id == searchModel.Id);

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query.Where(x => x.Name == searchModel.Name);

            return query.ToList();

        }
    }
}
