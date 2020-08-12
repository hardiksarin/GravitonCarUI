using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar.Rules
{
    public class FieldEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string temp = value as string;

            if(temp.Length == 0 || temp == null)
            {
                return new ValidationResult(false, "Field Required");
            }
            else
            {
                return new ValidationResult(true, "done");
            }
        }
    }
}
