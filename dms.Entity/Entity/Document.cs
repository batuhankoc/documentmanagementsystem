using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.Entity.Entity
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public int FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileType { get; set; }
        public int VersionNumber { get; set; }
        //public string UserId { get; set; }
        //public User User { get; set; }
        //public ICollection<DocumentVersion> DocumentVersions { get; set; }
        public ICollection<DocumentTag> DocumentTags { get; set; }

    }
}
