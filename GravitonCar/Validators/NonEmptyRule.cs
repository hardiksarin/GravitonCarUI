using System.Windows.Controls;
using System;
using System.Globalization;
using System.Text;
using System.Linq;


namespace GravitonCar.Validators
{
    class NonEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            string inputString = value as string;
            if (string.IsNullOrEmpty(inputString))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Field Can't Be Empty");

            }
            else
            {

                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
        }
    }
}
