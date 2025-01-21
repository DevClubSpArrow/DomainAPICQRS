using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditManagementDAL.DTOObject
{
    public class AuditManagementDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditManId { get; set; }
        [Required]
        public string? AuditCode { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string? CreatedBy { get; set; }
        [Required]
        public string? Operationunit { get; set; }
        [Required]
        public string? DepartmentCode { get; set; }
        [Required]
        public Guid AuditAreaId { get; set; }
        [Required]
        public string? AuditType { get; set; }
        [Required]
        public Guid AuditorId { get; set; }
        [Required]
        public string? AuditeeCode { get; set; }
        [Required]
        public string? FinancialYear { get; set; }
        [Required]
        public string? FinancialQuarter { get; set; }
        [Required]
        public DateTime AuditStartDate { get; set; }
        [Required]
        public DateTime AuditEndDate { get; set; }
        [Required]
        public Guid CommitteeId { get; set; }
        [Required]
        public string? ExpectedAuditMonth { get; set; }
        [Required]
        public DateTime AuditClosureDate { get; set; }
        [Required]
        public string? Status { get; set; }

    }
}
