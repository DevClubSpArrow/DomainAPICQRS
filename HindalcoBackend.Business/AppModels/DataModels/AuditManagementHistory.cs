using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditManagementHistory
    {
        #region "Primary Table"

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
        public Guid AuditAreaId { get; set; }

        [Required]
        public string? AreaId { get; set; }

        [Required]
        public string? AuditType { get; set; }

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

        public string? ExpectedAuditMonth { get; set; }

        [Required]
        public DateTime AuditClosureDate { get; set; }

        [Required]
        public int Status { get; set; }

        public string? AuditPlanUpdatedBy { set; get; }
        public DateTime AuditPlanUpdatedDate { set; get; }
        public Guid AuditPlanID { set; get; }

        #endregion "Primary Table"

        #region "Managing deletion History"

        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeletionId { get; set; }

        [Required]
        public int DeptID { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }

        #endregion "Managing deletion History"
    }
}