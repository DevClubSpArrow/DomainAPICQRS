using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Domain.DomainModels.DataModels
{
    public class AreaStandardMapper
    {
        [Required]
        public int SrNo { set; get; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StdAreaMapId { set; get; }

        [Required]
        public Guid SafetyStandardId { set; get; }

        [Required]
        public Guid AreaId { set; get; }

        [MaxLength(3)]
        [MinLength(1)]
        public int L2 { set; get; }

        [MaxLength(3)]
        [MinLength(1)]
        public int L3 { set; get; }

        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string? CreatedBy { set; get; }

        [DataType(DataType.Text)]
        public string? UpdatedBy { set; get; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { set; get; }

        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        public int IsActive { get; set; }
    }
}