using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Db.Entities
{
    [Table("Addresses")]
    public class AddressEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(CustomerEntity.Id))]
        public Guid CustomerId { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Number { get; set; }
        public string Complement { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        public virtual CustomerEntity Customer { get; set; }
    }
}