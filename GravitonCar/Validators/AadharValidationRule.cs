using System.Globalization;
using System.Windows.Controls;

using System;
using System.Text;
using System.Linq;

namespace GravitonCar.Validators
{
    class AadharValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;
            if (IsAadharValid.validateVerhoeff(v))
            {
                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));


            }

            else
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"InValid Aadhar!");

            }

        }
    }
}
