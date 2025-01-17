using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditObservationL2History
    {
   
    #region "Primary Table"
        public Guid AuditObsId { set; get; }
        public string? SrlNo { set; get; }
        public Guid StdDetailId { set; get; }
        public Guid AuditMasterId { set; get; }
        public string? Severity { set; get; }
        public string? NarrationOb { set; get; }
        public string? RootCauseObsAuditor { set; get; }
        public string? RootCauseObsAuditee { set; get; }
        public string? CorrectiveAction { set; get; }
        public string? PreventiveAction { set; get; }
        public string? ResponsPersonId { set; get; }
        public DateTime CompletionDate { set; get; }
        public byte[] UploadedImg { set; get; } = null;
        public int AuditStatus { set; get; }
        public string? ActivityLog { set; get; }
        public string? MachineTag { get; set; }
   
    #endregion  "Primary Table"

    #region "Managing deletion History"
        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeletionId { get; set; }

        [Required]
        public int DeptID { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }

    #endregion "Managing deletion History"
    }
}
