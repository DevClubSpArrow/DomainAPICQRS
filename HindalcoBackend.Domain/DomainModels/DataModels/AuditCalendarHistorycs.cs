using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditCalendarHistory
    {
        #region "Primary Table"

        public int AuditCalendarId { get; set; }
        public DateTime AuditStart { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string AuditName { get; set; }
        public string AreaCode { get; set; }
        public int DeptId { get; set; }
        public DateTime DocumentDate { get; set; }
        public string AuditCategory { get; set; }
        public string AuditType { get; set; }
        public string DocumentedBy { get; set; }

        #endregion "Primary Table"


        #region "Managing deletion History"

        public DateTime DateOfDeletion { get; set; }

        [Required]
        public string? DeletedByUserName { get; set; }

        [Key]
        public Guid DeletionId { get; set; }

        [Required]
        public int DeleterDeptID { get; set; }

        public int GeoTeamId { get; set; }

        [Required]
        public string? DeletedIPAddress { get; set; }

        #endregion "Managing deletion History"
    }
}