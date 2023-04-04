using System;

public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public long FileSize { get; set; }
    public DateTime UploadDate { get; set; }
    public string FilePath { get; set; }
    public int VersionNumber { get; set; }

    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int? FolderId { get; set; }
    public Folder Folder { get; set; }

    public ICollection<DocumentVersion> DocumentVersions { get; set; }
    public ICollection<DocumentTag> DocumentTags { get; set; }
}
