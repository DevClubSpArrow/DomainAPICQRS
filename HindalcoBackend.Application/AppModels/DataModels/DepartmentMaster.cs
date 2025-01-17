using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class DepartmentMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DepartmentId { get; set; } = Guid.NewGuid();

        [Required]
        public string? DepartmentName { get; set; }

        [Required]
        public string? DepartmentCode { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid OperationUnitCode { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        //public int IsActive { get; set; }

        public ICollection<OperationUnit>? OperationUnit { get; }
    }
}