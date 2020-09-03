using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar.Validators
{
    class MaximumCharacterRule : ValidationRule
    {

        public int MaximumCharacters { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            string inputString = value as string;
            if (inputString.Length > MaximumCharacters)
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Please Enter Maximum {MaximumCharacters} Characters!");

            }
            else
            {
                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
        }
    }
}
