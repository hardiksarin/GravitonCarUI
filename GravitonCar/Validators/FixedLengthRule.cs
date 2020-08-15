using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Linq;
namespace GravitonCar.Validators
{
    class FixedLengthRule : ValidationRule
    {
        public int FixedCharacters { get; set; }
        public string TypeOfData { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string inputString = value as string;
            if (inputString.Length != FixedCharacters)
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Please Enter {FixedCharacters} {TypeOfData}!");

            }
            else
            {

                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
        }
    }
}
