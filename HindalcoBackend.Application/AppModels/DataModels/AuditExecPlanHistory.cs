using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditExecPlanHistory
    {
        #region "Master Details"

        public int AuditPlanId { get; set; }

        [Required]
        public string? ExecutionStatus { get; set; }

        [Required]
        public string? ExcutionCategory { get; set; }

        [Required]
        public string? NarrationOfObservation { get; set; }

        public string? AuditorRCA { get; set; }
        public string? AuditeeRCA { get; set; }
        public byte[]? SnapshotImg { get; set; }

        [Required]
        public string? DeviationStandard { get; set; }

        [Required]
        public DateTime? AuditClosureDate { get; set; }

        [Required]
        public int? ExecutedBy { get; set; }

        [Required]
        public int? AuditExecutionId { get; set; }

        #endregion "Master Details"

        #region "Managing deletion History"

        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Required]
        public int DeptID { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeletionId { get; set; }

        #endregion "Managing deletion History"
    }
}