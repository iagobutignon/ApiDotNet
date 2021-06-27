using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Campo UserName obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Password obrigatório")]
        [MinLength(6, ErrorMessage = "A senha não pode conter menos que 6 caracteres!")]
        public string Password { get; set; }

    }
}