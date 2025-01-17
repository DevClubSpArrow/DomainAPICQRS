using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditAssignee
    {
        [Key]
        public int AssigneeFindId { get; set; }
        public int AuditeeId { get; set; }
        public int AssignedTo { get; set; }
        public DateTime AssignedDate { get; set; }
        public string? AuditeeStatus { get; set; }
    }
}