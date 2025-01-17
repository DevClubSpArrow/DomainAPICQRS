
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HindalcoBackend.Application.DataModels
{
    public class TaskDetails
    {
        [Key]
        public string? TaskCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskId { get; set; }

        [Required]
        [StringLength(50)]
        public string? TaskAssignedBy { get; set; }

        [Required]
        public string? TaskAssignedTo { get; set; }

        [Required]
        [StringLength(50)]
        public string? CurrentStatus { get; set; }

        [AllowNull]
        public string? FinalStatus { get; set; }

        [Required]
        public DateTime? createdDate { get; set; }

        [Required]
        public DateTime? ExpectedClosureDate { get; set; }

        [AllowNull]
        public DateTime? CorporateDateofClosure { get; set; }

        [Required]
        [StringLength(250)]
        public string? Description { get; set; }

        [AllowNull]
        public string? AuditorRemarks { get; set; }

        [AllowNull]
        public string? AuditeeRemarks { get; set; }

        [Required]
        [StringLength(150)]
        public string? CorporateRemarks { get; set; }

        [AllowNull]
        public string? UploadSupportDocs { get; set; }

        [Required]
        public string? FinalClosedByCorporateUser { get; set; }

        [AllowNull]
        public Guid AuditManId { get; set; }

        [AllowNull]
        public Guid AuditManDetId { get; set; }

        [AllowNull]
        public Guid AuditplanId { get; set; }
    }
}