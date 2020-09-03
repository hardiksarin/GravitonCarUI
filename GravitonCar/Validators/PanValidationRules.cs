using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GravitonCar.Validators
{
    class PanValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;


            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Z]{5}[0-9]{4}[A-Z]{1}$");
            Match match = regex.Match(v);
            if (match.Success)
            {
                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
            else
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Invalid Pan Number!");
            }


           

        }
    }
}
