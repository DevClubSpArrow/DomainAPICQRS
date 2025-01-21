using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DTOObject
{
    public class OperationUnitDTO
    {
        [Key]
        [Required]
        public Guid OperationUnitCode { get; set; }
        public string? OperationUnitName { get; set;}
    }
}
