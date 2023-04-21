using dms.Contract.DocumentContracts;
using dms.Contract.ResponseContracts;
using dms.Entity.Entity;
using dms.Service.Abstract;
using dms.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dms.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : BaseController
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDocumentAsync([FromForm] AddDocumentContract documentContract)
        {
            var result = await _documentService.AddDocumentAsync(documentContract);
            return ApiResponse(result);
        }

    }
}
