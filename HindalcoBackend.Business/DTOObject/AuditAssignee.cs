using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementDAL.DTOObject
{
    public  class AuditAssigneeDTO
    {
        [Key]
        public int AssigneeFindId { get; set; }
        public int AuditeeId { get; set; }
        public int AssignedTo { get; set; }
        public DateTime AssignedDate { get;set; }
        public string? AuditeeStatus { get;set; }

    }
}
