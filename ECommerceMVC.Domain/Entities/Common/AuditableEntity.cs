namespace ECommerceMVC.Domain.Entities.Common;

public class AuditableEntity
{
    public int Id { get; set; }

    public DateTimeOffset CreateTimeUtc { get; set; }
}
