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

    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly DataContext _context;

        public TagRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetByIdsAsync(IEnumerable<int> tagIds)
        {
            return await _context.Tags.Where(t => tagIds.Contains(t.Id)).ToListAsync();

        }
    }
}
