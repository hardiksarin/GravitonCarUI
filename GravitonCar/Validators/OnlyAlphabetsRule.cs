using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace GravitonCar.Validators
{
    class OnlyAlphabetsRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            string inputString = value as string;
            if (!inputString.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Please Enter A Valid Name");

            }
            else
            {

                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
        }
    }
}
