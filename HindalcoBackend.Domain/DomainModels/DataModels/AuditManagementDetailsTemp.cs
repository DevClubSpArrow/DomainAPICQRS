using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditManagementDetailsTemp
    {
        public Guid AuditManDetId { get; set; }
        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Key]
        public Guid DeletionId { get; set; }

        [Required]
        public int DeptID { get; set; }

        [Required]
        public Guid AuditAreaId { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }
    }
}