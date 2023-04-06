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
