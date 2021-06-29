using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api.Db.Entities
{
    [Index(nameof(UserName), IsUnique = true, Name = "UK_UserName")]
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }
}