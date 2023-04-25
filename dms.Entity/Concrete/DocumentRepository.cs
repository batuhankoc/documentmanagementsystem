using dms.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dms.Entity.Entity;

namespace dms.Entity.Concrete
{

    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        private readonly DataContext _context;

        public DocumentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        // Eğer Document'a özgü ekstra repository metotları olacaksa, buraya ekleyebilirsiniz.
    }
}
