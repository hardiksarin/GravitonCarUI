using System.Globalization;
using System.Windows.Controls;

using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Linq;
using System.Windows;

namespace GravitonCar.Validators
{
   public class OnlyNumericRule : ValidationRule
    {


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           string v = value as string;
            if (v.All(char.IsDigit))
            {
                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));

                             }

            else 
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();
                return new ValidationResult(false, $"Please Enter Numeric Charcters!");
            }

        }

     
    }
}
