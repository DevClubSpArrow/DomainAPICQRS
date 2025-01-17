using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditAssigned
    {
        [Required]
        public int AuditCalendarId { get; set; }

        [Required]
        [Key]
        public int AssignedId { get; set; }

        [Required]
        public int AssignedTo { get; set; }

        [Required]
        public string? AuditStatus { get; set; }
    }
}