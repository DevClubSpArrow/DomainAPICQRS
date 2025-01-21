using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DTOObject
{
    public class AuditExecutionPlanDTO
    {
        [Required]
        public int AuditPlanId { get; set; }
        [Required]
        public string? ExecutionStatus { get; set; }
        [Required]
        public string? ExcutionCategory { get; set;}
        [Required]
        public string ? NarrationOfObservation { get; set; }
        public string? AuditorRCA { get; set; }
        public string? AuditeeRCA { get;set; }
        public byte[]? SnapshotImg { get; set; }
        [Required]
        public string? DeviationStandard { get; set; }
        [Required]
        public DateTime? AuditClosureDate { get; set;}
        [Required]
        public int ? ExecutedBy { get; set; }
        [Required]
        [Key]
        public int? AuditExecutionId { get; set;}

    }
}
