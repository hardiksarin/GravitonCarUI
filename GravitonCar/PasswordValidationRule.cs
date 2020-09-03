
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GravitonCar.Validators
{
    class PasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {



            var input = value as string;
            

            if (string.IsNullOrWhiteSpace(input))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Password Shoud Not Be Empty!");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Password should contain at least one lower case letter.!");
               
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Password should contain at least one upper case letter!");
            }
            else if (!hasNumber.IsMatch(input))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Password should contain at least one numeric value.");
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Password should contain at least one special case character.");
            }
            else
            {
                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
        }

    }
}




