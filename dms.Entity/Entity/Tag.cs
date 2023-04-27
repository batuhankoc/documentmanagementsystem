namespace dms.Entity.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DocumentTag> DocumentTags { get; set; }
    }
}
