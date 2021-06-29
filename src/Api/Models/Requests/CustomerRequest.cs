using System;
using System.ComponentModel.DataAnnotations;
using Api.Attributes;

namespace Api.Models.Requests
{
    public class CustomerRequest
    {
        [Required(ErrorMessage = "Campo Name obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo CpfCnpj obrigatório")]
        [CpfCnpjValidation(ErrorMessage = "CPF / CNPJ inválido!")]
        public string CpfCnpj { get; set; }
        [Required(ErrorMessage = "Campo Type obrigatório")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Campo BirthDate obrigatório")]
        public DateTime BirthDate { get; set; }
    }
}