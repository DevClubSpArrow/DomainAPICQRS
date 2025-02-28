﻿using System.ComponentModel.DataAnnotations;

namespace HindalcoBackend.Business
{
    public class UserModel
    {
        [Key]
        [Required]
        [StringLength(30)]
        public string? UserName { get; set; }

        [Required]
        public int Uid { get; set; }

        [StringLength(120)]
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; } = null;
       
   //     public string? AuthRefreshToken { get; set; }
    }
}