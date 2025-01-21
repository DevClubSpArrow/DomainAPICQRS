using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DTOObject
{
    public class RolesDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleId { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public bool IsMaintenance { get; set; } = false;
        public bool IsOperation { get; set; } = false;
        public bool IsSafety { get; set; } = false; 
        public bool IsProduction { get; set; }=false;
        public bool IsU0User { get; set; } = false;
        public bool IsInventory { get; set; }   =false;
        public bool IsCorporate { get; set; } = false;

    }
}
