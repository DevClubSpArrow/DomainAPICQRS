using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DTOObject
{
    public class AuditCalendarDTO
    {
        public int AuditCalendarId { get; set; }
        public DateTime AuditStart { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string? AuditName { get; set; }
        public string? AreaCode { get; set; }
        public int DeptId { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? AuditCategory { get; set; }
        public string? AuditType { get; set; }
        public string? DocumentedBy { get; set; }

    }
}