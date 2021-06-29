using System;

namespace Api.Models.Requests
{
    public class AddressRequest
    {
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