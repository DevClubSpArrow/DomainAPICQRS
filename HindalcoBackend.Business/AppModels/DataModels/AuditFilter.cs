namespace HindalcoBackend.Application.DataModels
{
    public class AuditFilter
    {
        public string? FromYear { get; set; }
        public string? ToYear { get; set; }
        public string? AuditType { get; set; }
        public Guid AuditAreaID { get; set; }
        public string? UserId { get; set; }
        public string? TableName { get; set; }
    }
}