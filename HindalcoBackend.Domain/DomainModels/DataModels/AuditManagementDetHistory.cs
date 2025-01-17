using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditManagementDetHistory
    {
        public string? SrlNo { get; set; }
        public Guid DeviaSafetyStd { get; set; }
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

        [Required]
        public Guid AuditManId { get; set; }

        [Required]
        public Guid AuditManDetId { get; set; }

        public Guid AuditMasterId { get; set; }

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