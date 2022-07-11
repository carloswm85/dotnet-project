namespace Telerik.Project.Management.Models;

public class ChangeSet
{
    public ChangeSet()
    {
        this.Changes = new List<ChangeInfo>();
    }

    public string? Id { get; set; }
    public string? ParentId { get; set; }
    public DateTime? Modified { get; set; }
    public List<ChangeInfo> Changes { get; }
}
