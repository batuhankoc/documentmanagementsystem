using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dms.Entity.Entity;

namespace dms.Contract.DocumentContracts
{
    public class AddDocumentContract
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string UserId { get; set; }
        public int? FolderId { get; set; }
        public int VersionNumber { get; set; }
        public List<Tag> Tags { get; set; }
    }



}
