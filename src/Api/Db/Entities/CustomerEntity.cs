using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api.Db.Entities
{
    [Index(nameof(CpfCnpj), IsUnique = true, Name = "UK_CpfCnpj")]
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(14)")]
        public string CpfCnpj { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(8)")]
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}