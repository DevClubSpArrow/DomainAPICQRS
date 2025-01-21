using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Business
{
    public class AuditMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditMasterId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLengthAttribute]
        public string? AuditCheckPoint { get; set; }

        [Required]
        public string? AuditCategoryId { get; set; }

        [DataType(DataType.Text)]
        [MaxLengthAttribute]
        public string? AuditRemarks { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string? AuditCreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AuditUpdatedDate { get; set; }

        [StringLength(50)]
        public string? AuditUpdatedBy { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        public int IsActive { get; set; }
    }
}