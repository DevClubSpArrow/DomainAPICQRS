using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class OperationUnit
    {
        [Key]
        [Required]
        public Guid OperationUnitCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OperationUnitId { get; set; }

        public string? OperationUnitName { get; set; }
    }
}