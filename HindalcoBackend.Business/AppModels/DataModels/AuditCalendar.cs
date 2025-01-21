using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Business
{
    public class AuditCalendar
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuditCalendarId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AuditStart { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ExpectedDate { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string? AuditName { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string? AreaCode { get; set; }

        [Required]
        [MaxLength(5)]
        public int DeptId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DocumentDate { get; set; }

        [Required]
        public string? AuditCategory { get; set; }

        [Required, MaxLength(50), DataType(DataType.Text)]
        public string? AuditType { get; set; }

        [Required, MaxLength(50), DataType(DataType.Text)]
        public string? DocumentedBy { get; set; }
    }
}