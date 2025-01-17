using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditManageDetHistory
    {
        public string? SrlNo { get; set; }
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

        [Key]
        [Required]
        public Guid AuditManDetId { get; set; }

        public Guid AuditMasterId { get; set; }

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