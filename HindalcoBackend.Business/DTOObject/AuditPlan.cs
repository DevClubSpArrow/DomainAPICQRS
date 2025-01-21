using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditManagementDAL.DTOObject
{
    public class AuditPlanDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditplanId { get; set; }
        [Required]
        public string? AuditCode { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        [ForeignKey("OperationUnit")]
        public string? OperationUnit { get; set; }
        [Required]
        public string? AuditType { get; set; }
        [Required]
        public string? FinancialYear { get; set; }
        [Required]
        public string? FinancialQuarter { get; set; }
        [Required]
        [ForeignKey("DepartmentMaster")]
        public Guid DepartmentId { get; set; }
        [Required]
        [ForeignKey("UserModel")]
        public string? AuditeeCode { get; set; }
        [Required]
        public DateTime AuditClosureDate { get; set; }
        [Required]
        public string? ExpectedClosureMonth { get; set; }
        [Required]
        public DateTime AuditStartDate { get; set; }
        [Required]
        public DateTime AuditEndDate { get; set; }
        [Required]
        public Guid AuditorId { get; set; }
        [Required]
        [ForeignKey("AuditCommitee")]
        public Guid CommitteeId { get; set; }
        public Guid AuditPlanUpdatedBy { get; set; }
        public DateTime AuditPlanUpdatedDate { get; set; }
        public ICollection <AuditCommiteeDTO>? auditCommitees { get;}
        public ICollection<UserModelDTO>? userModels { get; }
        public ICollection <DepartmentMasterDTO>? departmentMasters { get; }
    
    }
}
