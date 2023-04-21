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
using dms.Contract.ResponseContracts;
using Microsoft.EntityFrameworkCore;

namespace dms.Service.Concrete
{
    public class DocumentService : BaseService<Document>, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly BlobStorageService _blobStorageService;


        public DocumentService(IDocumentRepository documentRepository, IMapper mapper, BlobStorageService blobStorageService) : base(documentRepository)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
        }

        public async Task<ApiResponse<Document>> AddDocumentAsync(AddDocumentContract contract)
        {
            var document = _mapper.Map<Document>(contract);

            document.DocumentTags = new List<DocumentTag>();
            foreach (var tagId in contract.TagIds)
            {
                document.DocumentTags.Add(new DocumentTag { DocumentId = document.Id, TagId = tagId });
            }

            var fileUrl = await _blobStorageService.UploadFileAsync(contract.File);
            document.FilePath = fileUrl;
            var newDocument = await _documentRepository.AddAsync(document);

            return ApiResponse<Document>.Success(newDocument);
        }

    }
}
