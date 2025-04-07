using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MvcCore.Helpers
{
    public class CustomValidationMetadataProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            // Set the ErrorMessage for all validation attributes 
            foreach (var validationAttribute in context.ValidationMetadata.ValidatorMetadata.OfType<ValidationAttribute>())
            {
                if (validationAttribute is EmailAddressAttribute)
                {
                    validationAttribute.ErrorMessage = "El campo {0} no es una dirección de correo electrónico válida.";
                }
                else if (validationAttribute is StringLengthAttribute stringLength && stringLength.MinimumLength > 0)
                {
                    validationAttribute.ErrorMessage = "El campo {0} debe ser un texto con una longitud mínima de {2} y máxima de {1}.";
                }
                else if (validationAttribute is StringLengthAttribute)
                {
                    validationAttribute.ErrorMessage = "El campo {0} debe ser un texto con una longitud máxima de {1}.";
                }
                else if (validationAttribute is RangeAttribute)
                {
                    validationAttribute.ErrorMessage = "El campo {0} debe ser un valor entre {1} y {2}.";
                }
                else if (validationAttribute is RequiredAttribute)
                {
                    validationAttribute.ErrorMessage = "El campo {0} es obligatorio.";
                }
            }
        }
    }
}