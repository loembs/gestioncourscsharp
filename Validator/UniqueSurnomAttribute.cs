using System.ComponentModel.DataAnnotations;
using GestionCours.Services;

namespace GestionCours.Validator;

public class UniqueSurnomAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var clientService = (IClientService)validationContext.GetService(typeof(IClientService));
        var surnom = (string)value;

        if (clientService.GetClientsAsync().Result.Any(c => c.Surnom == surnom))
        {
            return new ValidationResult("Ce surnom est déjà utilisé.");
        }
       
        return ValidationResult.Success;
    }
}
