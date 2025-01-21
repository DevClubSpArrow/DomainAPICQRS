using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DTOObject
{
    public class AuditCommiteeDTO
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string MemberType { get; set; }
        [Required]
        public string CommiteeName { get; set; }
        [Required]
        public DateTime CreatedDate { get;set; }

        [Required]
        public int CreatedBy { get;set; }
        [Key]
        [Required]
        public Guid CommitteeId { get;set; }

    }
}
