using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar
{
 public class MinimumCharacterRule :ValidationRule
    {
       public int MinimumCharacters { get; set; } 
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            

                string inputString = value as string;
            if (inputString.Length < MinimumCharacters)
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Please Enter Minimum {MinimumCharacters} Characters!");

            }
            else
            {

                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));
            }
        }
    }
}
