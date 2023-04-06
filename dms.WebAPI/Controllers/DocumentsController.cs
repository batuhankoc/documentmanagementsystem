using dms.Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dms.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DataContext _context;

        public DocumentsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("addDocument")]
        public IActionResult AddDocument([FromBody] Document document)
        {
            if (document == null)
            {
                return BadRequest("Document is null.");
            }

            _context.Documents.Add(document);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDocumentById), new { id = document.Id }, document);
        }

        [HttpGet("{id}")]
        public IActionResult GetDocumentById(int id)
        {
            var document = _context.Documents.Find(id);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpPost("addDocumentVersion")]
        public IActionResult AddDocumentVersion([FromBody] DocumentVersion documentVersion)
        {
            if (documentVersion == null)
            {
                return BadRequest("DocumentVersion is null.");
            }

            _context.DocumentVersions.Add(documentVersion);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDocumentVersionById), new { id = documentVersion.Id }, documentVersion);
        }

        [HttpGet("documentVersion/{id}")]
        public IActionResult GetDocumentVersionById(int id)
        {
            var documentVersion = _context.DocumentVersions.Find(id);

            if (documentVersion == null)
            {
                return NotFound();
            }

            return Ok(documentVersion);
        }
    }
}
