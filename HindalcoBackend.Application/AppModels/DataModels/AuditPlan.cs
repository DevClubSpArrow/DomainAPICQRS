using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditPlan
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditplanId { get; set; }

        [Required]
        public string? AuditCode { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        [ForeignKey("OperationUnit")]
        public string? OperationUnit { get; set; }

        [Required]
        public string? AuditType { get; set; }

        [Required]
        public string? FinancialYear { get; set; }

        [Required]
        public string? FinancialQuarter { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Guid AuditAreaId { get; set; }

        [Required]
        public string? AuditeeId { get; set; }

        [Required]
        public DateTime AuditClosureDate { get; set; }

        [Required]
        public string? ExpectedClosureMonth { get; set; }

        [Required]
        public DateTime AuditStartDate { get; set; }

        [Required]
        public DateTime AuditEndDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string? AuditorId { get; set; }

        [Required]
        [ForeignKey("AuditCommitee")]
        public Guid CommitteeId { get; set; }

        public string? CommitteeMemId { get; set; }
        public string? AuditPlanUpdatedBy { get; set; }
        public DateTime AuditPlanUpdatedDate { get; set; }
        public ICollection<AuditCommitee>? auditCommitees { get; }

        //   public ICollection<UserModel>? userModels { get; }
        public ICollection<DepartmentMaster>? departmentMasters { get; }

        public int? DocStatus { get; set; }
    }
}