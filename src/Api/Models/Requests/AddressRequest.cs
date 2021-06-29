using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests
{
    public class AddressRequest
    {
        [Required]
        [StringLength(9, MinimumLength = 8)]
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
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
    }
}