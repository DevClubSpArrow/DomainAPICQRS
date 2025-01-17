using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class ModelRBAC
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RbacId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public Guid? ModuleId { get; set; }

        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdate { get; set; }

        [Required]
        public DateTime createdDate { get; set; }
    }
}