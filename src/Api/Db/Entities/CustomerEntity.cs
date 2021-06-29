using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Api.Db.Entities
{
    [Table("Customers")]
    [Index(nameof(CpfCnpj), IsUnique = true, Name = "UK_CpfCnpj")]
    public class CustomerEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(14)")]
        [CpfCnpjValidation(ErrorMessage = "CPF / CNPJ inválido!")]
        public string CpfCnpj { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(8)")]
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AddressEntity> Addresses { get; set; }
    }
}