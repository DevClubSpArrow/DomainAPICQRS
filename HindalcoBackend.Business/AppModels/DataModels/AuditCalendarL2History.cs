using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Business
{
    public class AuditCalendarL2History
    {

        #region "Primary Table"

        public Guid AuditplanId { set; get; }

        [Required]
        public string? AuditCode { set; get; }

        public DateTime CreatedDate { set; get; }

        [Required]
        public string? CreatedById { set; get; }

        [Required]
        public string? OperationUnit { set; get; }

        [Required]
        public string? AuditType { set; get; }

        [Required]
        public string? FinancialYear { set; get; }

        [Required]
        public string? FinancialQuarter { set; get; }

        [Required]
        public int DepartmentId { set; get; }
        public Guid AuditAreaId { set; get; }
        public string? AuditeeId { set; get; }
        public DateTime AuditClosureDate { set; get; }
        public string? ExpectedClosureMonth { set; get; }
        public DateTime AuditStartDate { set; get; }
        public DateTime AuditEndDate { set; get; }

        [Required]
        public string? CommitteeMemId { set; get; }
        public string? AuditPlanUpdatedBy { set; get; }
        public DateTime AuditPlanUpdatedDate { set; get; }

        [Required]
        public int DocStatus { set; get; }

        #endregion

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
