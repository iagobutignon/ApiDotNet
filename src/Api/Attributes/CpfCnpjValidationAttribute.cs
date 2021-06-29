using System.ComponentModel.DataAnnotations;
using Api.Extensions;

namespace Api.Attributes
{
    public class CpfCnpjValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value?.ToString().CpfCnpjOk() ?? false;
        }
    }
}