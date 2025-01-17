namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditPlanRequest
    {
        public int DepartmentId { get; set; }
        public string? AuditType { get; set; }
        public string? AuditYear { get; set; }
        public string? AuditQtr { get; set; }
    }
}