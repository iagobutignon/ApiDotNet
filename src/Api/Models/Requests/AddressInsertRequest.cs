using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests
{
    public class AddressInsertRequest : AddressRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}