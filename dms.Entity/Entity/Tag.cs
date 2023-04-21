using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.Entity.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DocumentTag> DocumentTags { get; set; }
    }
}
