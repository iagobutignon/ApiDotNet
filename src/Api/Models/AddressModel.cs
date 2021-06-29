using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Db.Entities;

namespace Api.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Cep { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}