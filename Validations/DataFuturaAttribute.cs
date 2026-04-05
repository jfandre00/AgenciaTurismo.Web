using System;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Web.Validations
{
    public class DataFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dataInformada)
            {
                if (dataInformada.Date < DateTime.Now.Date)
                {
                    return new ValidationResult(ErrorMessage ?? "A data não pode estar no passado.");
                }
            }
            return ValidationResult.Success; 
        }
    }
}