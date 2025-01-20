using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditManagementStdDetaiL2
    {
        [Required]
        public Guid SafetyStandardId { set; get; }

        [Required]
        public string? StdSrlNo { set; get; }

        [Required]
        public string? AuditorId { set; get; }

        [Required]
        public int Status { set; get; }

        [Required]
        public Guid AuditManId { set; get; }

        [Key]
        [Required]
        public Guid StdDetailId { set; get; }

        public string? UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }
        public byte[]? FileAttachment { set; get; }
        public string? Remarks { set; get; }
    }
}