using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class ModuleMaster
    {
        [Required]
        public string? ModuleName { get; set; }

        [Required]
        public string? ProjectName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? ModuleId { get; set; }
    }
}