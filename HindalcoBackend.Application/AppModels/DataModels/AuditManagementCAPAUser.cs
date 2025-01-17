using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditManagementCAPAUser
    {
        [Key]
        public string? SrlNo { get; set; }

        [Required]
        public string? AuditCode { get; set; }

        [Required]
        public string? AuditType { get; set; }

        public string? DeviaSafetyStd { get; set; } = null;
        public string? RiskCategory { get; set; } = null;
        public string? CateOfObs { get; set; } = null;
        public string? NarrationOb { get; set; } = null;
        public string? RootCauseObsAuditor { get; set; } = null;
        public string? RootCauseObsAuditee { get; set; } = null;
        public string? CorrectiveAction { get; set; } = null;
        public string? PreventiveAction { get; set; } = null;
        public string? ResponsPersonId { get; set; } = null;
        public DateTime? CompletionDate { get; set; } = null;
        public byte[]? UploadedImg { get; set; } = null;

        [Required]
        public int? AuditStatus { get; set; }

        [ForeignKey("AuditManagement")]
        [Required]
        public Guid AuditManId { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public string? Operationunit { get; set; }

        [Required]
        public string? DepartmentId { get; set; }

        [Required]
        public string? AreaId { get; set; }

        [Required]
        public string? AuditorId { get; set; }

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

        public string? ExpectedAuditMonth { get; set; } = null;

        [Required]
        public DateTime AuditClosureDate { get; set; }

        [Required]
        public int Status { get; set; }

        public string? AuditPlanUpdatedBy { set; get; }
        public DateTime AuditPlanUpdatedDate { set; get; }
    }
}