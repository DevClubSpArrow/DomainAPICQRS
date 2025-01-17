using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditManagementL2
    {
        [Key]
        [Required]
        public Guid AuditManId { get; set; }

        [Required]
        public string? AuditCode { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public string? Operationunit { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public Guid AuditAreaId { get; set; }

        [Required]
        public string? AuditType { get; set; }

        [Required]
        public string? FinancialYear { get; set; }

        [Required]
        public string? FinancialQuarter { get; set; }

        [Required]
        public DateTime AuditStartDate { get; set; }

        [Required]
        public DateTime AuditEndDate { get; set; }

        [Required]
        public string? CommiteeMemId { get; set; }

        [Required]
        public string? AuditeeId { get; set; }

        public string? ExpectedAuditMonth { get; set; }

        [Required]
        public DateTime AuditClosureDate { get; set; }

        [Required]
        public int Status { get; set; }

        public string? AuditPlanUpdatedBy { set; get; }
        public DateTime AuditPlanUpdatedDate { set; get; }
        public Guid AuditPlanID { set; get; }
        public string? Remarks { get; set; }
    }
}