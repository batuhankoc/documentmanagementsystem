using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dms.Entity.Entity;
using Microsoft.AspNetCore.Http;

namespace dms.Contract.DocumentContracts
{
    public class AddDocumentContract
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string FileUrl { get; set; }
        public string UserId { get; set; }
        public int VersionNumber { get; set; }
        public List<int>? TagIds { get; set; }
        public IFormFile File { get; set; }
    }
}
