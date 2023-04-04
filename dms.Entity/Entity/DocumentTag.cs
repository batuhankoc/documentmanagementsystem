using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dms.Entity.Entity
{
    public class DocumentTag
    {
        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
