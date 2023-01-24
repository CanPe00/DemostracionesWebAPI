using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibros.Validations
{
    public class FechaNacAtributte : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value).Year > 1950)
            {
                return ValidationResult.Success;

            }
            return new ValidationResult("Solo se aceptan fechas mayores al año 01/01/1950");
        }
    }
}
