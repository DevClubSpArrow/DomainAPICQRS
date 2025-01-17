using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditObservationTempL2
    {
        public Guid AuditObsId { get; set; }
        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Key]
        public Guid DeletionId { get; set; }

        [Required]
        public int DeptID { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }
    }
}
