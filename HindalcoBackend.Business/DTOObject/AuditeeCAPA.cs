using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementDAL.DTOObject
{
    public class AuditeeCAPADTO
    {
        public int AuditeeId { get; set; }
        [Key]
        public int CapaId { get; set; }
        public DateTime CapaFillDate { get; set; }
        public string CapaStatus { get; set; }
        public DateTime CapaUpdDate { get; set; }
        public string CapaUpdBy { get; set; }

    }
}
