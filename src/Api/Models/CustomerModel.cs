using System;
using System.Collections.Generic;
using Api.Db.Entities;

namespace Api.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
    }
}