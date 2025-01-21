using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementDAL.DTOObject
{
    public class AuditAssignedDTO
    {
       
        [Required]
        public int AuditCalendarId { get; set; }
        [Required]
        [Key]
        public int AssignedId { get; set; }
        [Required]
        public int AssignedTo { get; set; }
        [Required]
        public string? AuditStatus { get; set; }

    }
}
