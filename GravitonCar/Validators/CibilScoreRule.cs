using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar.Validators
{
    class CibilScoreRule : ValidationRule
    {
        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;
            
            int valueint = int.Parse(v);






            if ((valueint >= MinimumValue && valueint <= MaximumValue) || valueint == 0)
            {
                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return (new ValidationResult(true, null));


            }
            

            else
            {
                ApplicantDetailsFormUserControl.errorForm.DisableButton();

                return new ValidationResult(false, $"Input Can Only Be Between {MinimumValue} and {MaximumValue}.");

            }
        }
    }
}
