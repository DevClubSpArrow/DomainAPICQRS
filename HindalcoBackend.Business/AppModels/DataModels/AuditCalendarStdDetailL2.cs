using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Business
{
    public class AuditCalendarStdDetailL2
    {
        public Guid SafetyStandardId { set; get; }

        [Required]
        public string? StdSrlNo { set; get; }

        public string? AuditorId { set; get; }

        [Required]
        public int Status { set; get; }

        public Guid AuditPlanId { set; get; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid StdDetailId { set; get; }

        public string? UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }
        public string? Remarks { set; get; }
    }
}