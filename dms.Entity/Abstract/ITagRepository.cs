using dms.Entity.Entity;

namespace dms.Entity.Abstract
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetByIdsAsync(IEnumerable<int> tagIds);
    }
}
