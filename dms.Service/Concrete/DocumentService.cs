using dms.Entity.Abstract;
using dms.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dms.Entity.Entity;
using AutoMapper;
using dms.Contract.DocumentContracts;

namespace dms.Service.Concrete
{
    public class DocumentService : BaseService<Document>, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper) : base(documentRepository)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task AddDocumentAsync(AddDocumentContract addDocumentContract)
        {

        }

    }
}
