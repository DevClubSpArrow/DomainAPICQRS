using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HindalcoBackend.Application.DataModels
{
    public class UsersCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public long PhoneNumber { get; set; }
        public int RetryAttempts { get; set; }
        public bool IsActivated { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? DeactivatedDateTime { get; set; }
        public DateTime? LockedDateTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }

        [ForeignKey("Roles")]
        public int RoleID { get; set; }

        public int ProjectID { get; set; }

        [ForeignKey("Roles")]
        public int GeoTeamId { get; set; }

        [ForeignKey("DepartmentMaster")]
        public int DeptID { get; set; }

        public string? SecretQuestion { get; set; }
        public string? SecretAnswer { get; set; }

        [Required]
        public string? EmpCode { get; set; }
    }
}