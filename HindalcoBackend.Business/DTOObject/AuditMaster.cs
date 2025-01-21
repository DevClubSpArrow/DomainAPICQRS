using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditManagementDAL.DTOObject
{
    public class AuditMasterDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditMasterId { get; set; } = Guid.NewGuid();
        [Required]
        public string? AuditCheckPoint{ get; set;}
        [Required]
        public Guid AuditCheckPointId { get; set; }
        [Required]
        public Guid AuditCategoryId { get; set;  }
        public string? AuditRemarks { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid AuditCreatedBy { get; set;}
        public DateTime AuditUpdatedDate { get; set; }
        public Guid AuditUpdatedBy { get; set; }

    }
}
