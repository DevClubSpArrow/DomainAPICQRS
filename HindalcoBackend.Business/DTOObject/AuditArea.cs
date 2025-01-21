using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql;

namespace AuditManagementDAL.DTOObject
{
    public class AuditAreaDTO
    {
        [Required]
        public string? DepartmentCode { get; set; }
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditAreaId { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        public string AreaCode { get; set; }
       
    }
}
