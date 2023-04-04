using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.Entity.Entity
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int? ParentFolderId { get; set; }
        public Folder ParentFolder { get; set; }

        public ICollection<Folder> ChildFolders { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
