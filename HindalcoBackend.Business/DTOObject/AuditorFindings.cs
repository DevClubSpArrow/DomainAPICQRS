using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementDAL.DTOObject
{
    public  class AuditorFindingsDTO
    {
        public int AssignedId { get; set; }
        [Key]
        [Required]
        public int AssigneeFindId { get; set; }
        [Required]
        public string? AssigneeFindings { get; set; }
        [Required]
        public DateTime FindingDate { get; set; }
        [Required]
        public string? FindingStatus { get; set; }
    }
}
