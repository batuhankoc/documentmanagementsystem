using dms.Entity.Abstract;
using dms.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dms.Entity.Entity;

namespace dms.Service.Concrete
{
    public class DocumentService : BaseService<Document>, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository) : base(documentRepository)
        {
            _documentRepository = documentRepository;
        }
    }
}
