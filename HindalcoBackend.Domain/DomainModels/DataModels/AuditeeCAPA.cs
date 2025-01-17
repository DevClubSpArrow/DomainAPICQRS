using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditeeCAPA
    {
        public int AuditeeId { get; set; }

        [Key]
        public int CapaId { get; set; }

        public DateTime CapaFillDate { get; set; }
        public string? CapaStatus { get; set; }
        public DateTime CapaUpdDate { get; set; }
        public string? CapaUpdBy { get; set; }
    }
}