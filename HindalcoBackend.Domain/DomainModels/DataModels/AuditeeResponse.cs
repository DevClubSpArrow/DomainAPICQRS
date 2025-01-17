using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AuditeeResponse
    {
        [Key]
        public string? TaskCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskId { get; set; }

        public string? TaskAssignedBy { get; set; }
        public string? TaskAssignedTo { get; set; }
        public string? CurrentStatus { get; set; }
        public string? FinalStatus { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? ExpectedClosureDate { get; set; }
        public DateTime? CorporateDateofClosure { get; set; }
        public string? Description { get; set; }
        public string? AuditorRemarks { get; set; }

        //  public string? AuditeeRemarks { get; }
        public string? CorporateRemarks { get; set; }

        public string? UploadSupportDocs { get; set; }
        public string? FinalClosedByCorporateUser { get; set; }
        public Guid AuditManId { get; set; }
        public Guid AuditManDetId { get; set; }
        public Guid AuditplanId { get; set; }
    }
}