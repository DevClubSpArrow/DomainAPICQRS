using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class Roles
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        public string? RoleName { get; set; }

        public bool IsMaintenance { get; set; } = false;
        public bool IsOperation { get; set; } = false;
        public bool IsSafety { get; set; } = false;
        public bool IsProduction { get; set; } = false;
        public bool IsU0Login { get; set; } = false;
        public bool IsInventory { get; set; } = false;
        public bool IsCorporate { get; set; } = false;
        public bool IsAuditee { get; set; } = false;
        public bool IsAuditor { get; set; } = false;
        public bool IsCommHead { get; set; } = false;
        public bool IsCommMem { get; set; } = false;
        public bool IsTaskForce { get; set; } = false;
        public bool IsCapa { get; set; } = false;
    }
}