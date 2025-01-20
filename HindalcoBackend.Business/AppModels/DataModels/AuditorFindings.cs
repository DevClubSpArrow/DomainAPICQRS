using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Application.DataModels
{
    public class AuditorFindings
    {
        public int AssignedId { get; set; }

        [Key]
        [Required]
        public int AssigneeFindId { get; set; }

        [Required]
        public string AssigneeFindings { get; set; }

        [Required]
        public DateTime FindingDate { get; set; }

        [Required]
        public string FindingStatus { get; set; }
    }
}