using System.ComponentModel.DataAnnotations;
using static AppCamera.Entities.Constants.ValidationMessages;

namespace AppCamera.Entities.Attributes
{
    public class MaxIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int iso = (int)value;

            if (iso % 100 == 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(MaxIsoValidationMessage);
        }
    }
}
