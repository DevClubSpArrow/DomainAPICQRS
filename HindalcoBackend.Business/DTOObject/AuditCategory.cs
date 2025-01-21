using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AuditManagementDAL.DTOObject
{
    //[PrimaryKey(nameof(AuditCategoryId), nameof(AuditCategoryCode))]
    [PrimaryKey(nameof(AuditCategoryCode))]
    public class AuditCategoryDTO
    {
        [Required]
        public string? AuditCategoryName { get; set; }
        [Required]
        public string? AuditCategoryCode { get; set; }
        [Required]
        [ForeignKey("DepartmentMaster")]
        public string? DepartmentCode { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditCategoryId { get; set; }= Guid.NewGuid();
        [Required]
        public Guid AuditCreatedBy { get; set; }
        [Required]
        public DateTime AuditUpdatedDate { get; set; }
        [Required]
        public Guid AuditUpdatedBy { get; set; }
        public DateTime AuditCreatedDate { get;set; }
        public ICollection<DepartmentMasterDTO>? DepartMentMaster { get; }
    }
}
