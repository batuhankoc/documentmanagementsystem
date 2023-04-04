using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.Entity.Entity
{
    public class DocumentVersion
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string FilePath { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
