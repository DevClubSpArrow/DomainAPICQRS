using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditPlanHistory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeletionId { get; set; }

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

        [Required]
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
        public string? AuditorId { get; set; }

        [Required]
        [ForeignKey("AuditCommitee")]
        public string? CommitteeMemId { get; set; }

        public string? AuditPlanUpdatedBy { get; set; }
        public DateTime AuditPlanUpdatedDate { get; set; }
        public int? DocStatus { get; set; }

        #region "Managing deletion History"

        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Required]
        public int DeptID { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }

        #endregion "Managing deletion History"
    }
}