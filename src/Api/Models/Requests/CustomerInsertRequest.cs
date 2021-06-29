using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests
{
    public class CustomerInsertRequest : CustomerRequest
    {
        [Required]
        [MinLength(1)]
        public IEnumerable<AddressRequest> Addresses { get; set; }
    }
}