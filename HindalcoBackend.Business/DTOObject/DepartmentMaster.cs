using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditManagementDAL.DTOObject
{
    public class DepartmentMasterDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DepartmentId { get; set; }=Guid.NewGuid();
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? CreatedBy { get; set; }
        [Required]
        public string? DepartmentCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid OperationUnitCode { get; set; }
        public ICollection <OperationUnitDTO>? OperationUnit { get;}

    }
}
