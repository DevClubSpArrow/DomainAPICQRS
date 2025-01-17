using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditManagementDetails
    {
        public string? SrlNo { get; set; }

        // [Required]
        // public string? AuditCode { get; set; }
        //[Required]
        //public string? AuditType { get; set; }
        public Guid DeviaSafetyStd { get; set; }

        //    public string? AuditCheckPoint { get; set; }
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
        public string? ActivityLog { get; set; }

        [ForeignKey("AuditManagement")]
        [Required]
        public Guid AuditManId { get; set; }
        [Key]
        [Required]
        public Guid AuditManDetId { get; set; }

        public Guid AuditMasterId { get; set; }
        //   public ICollection<AuditManagement>? auditManagements { get; }
        //   public ICollection<AuditMaster>? auditMasters { get; }

        public Guid AreaId { set; get; }
        public byte[]? UploadedImgAfter { set; get; } = null;
    }
}