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
using dms.Entity.Concrete;

namespace dms.Service.Concrete
{
    public class DocumentService : BaseService<Document>, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly BlobStorageService _blobStorageService;


        public DocumentService(IDocumentRepository documentRepository, IMapper mapper, BlobStorageService blobStorageService, ITagRepository tagRepository) : base(documentRepository)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
            _tagRepository = tagRepository;
        }

        public async Task<ApiResponse<Document>> AddDocumentAsync(AddDocumentContract contract)
        {
            var document = _mapper.Map<Document>(contract);

            document.DocumentTags = new List<DocumentTag>();
            var errorMessage = await AddTagsToDocumentAsync(contract, document);
            if (errorMessage != null)
                return ApiResponse<Document>.Error(errorMessage);
            
            var fileUrl = await _blobStorageService.UploadFileAsync(contract.File);
            document.FileUrl = fileUrl;
            document.FileType = contract.File.ContentType;
            document.FileSize = (int)contract.File.Length;

            var newDocument = await _documentRepository.AddAsync(document);

            return ApiResponse<Document>.Success(newDocument);
        }

        #region Privates
        private async Task<string?> AddTagsToDocumentAsync(AddDocumentContract contract, Document document)
        {
            if (contract.TagIds == null) return null;
            var existingTags = await _tagRepository.GetByIdsAsync(contract.TagIds);
            var existingTagIds = existingTags.Select(tag => tag.Id).ToHashSet();

            if (existingTagIds.Count != contract.TagIds.Count)
            {
                var notFoundTagIds = contract.TagIds.Except(existingTagIds).ToList();
                var notFoundTagIdsString = string.Join(", ", notFoundTagIds);
                return $"The following tags were not found in the database: {notFoundTagIdsString}";
            }

            document.DocumentTags = existingTags.Select(tag => new DocumentTag { DocumentId = document.Id, TagId = tag.Id }).ToList();

            return null;
        }
        #endregion
    }
}
