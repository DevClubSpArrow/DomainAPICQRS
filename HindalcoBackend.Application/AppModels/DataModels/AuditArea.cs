using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditArea
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditAreaId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? AreaName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string? AreaCode { get; set; }

        public Guid OperationUnitId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        public int IsActive { get; set; }
    }
}