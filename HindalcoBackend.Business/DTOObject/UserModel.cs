using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DTOObject
{
    public class UserModelDTO
    {
        [Key]
        [Required]
        public string? UserName { get; set; }
        public string? Password { get; set; } = null;

    }
}
