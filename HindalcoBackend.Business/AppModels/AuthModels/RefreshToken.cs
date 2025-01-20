using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HindalcoBackend.Business
{
    public class AuthRefreshToken
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public DateTime TokenCreationDate { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }
        [Required]
        public int Uid { get; set; }
    }
}
