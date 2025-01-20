using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditObservationDetailL2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditObsId { set; get; }

        public string? SrlNo { set; get; }

        public Guid StdDetailId { set; get; }
        public Guid AuditMasterId { set; get; }
        public string? Severity { set; get; }
        public string? NarrationOb { set; get; }
        public string? RootCauseObsAuditor { set; get; }
        public string? RootCauseObsAuditee { set; get; }
        public string? CorrectiveAction { set; get; }
        public string? PreventiveAction { set; get; }
        public string? ResponsPersonId { set; get; }
        public DateTime CompletionDate { set; get; }
        public byte[] UploadedImg { set; get; } = null;
        public int AuditStatus { set; get; }
        public string? ActivityLog { set; get; }
        public string? MachineTag { get; set; }
        public Guid AreaId { set; get; }
        public byte[] UploadedImgAfter { set; get; } = null;
    }
}