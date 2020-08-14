using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Car.Validators
{
    class MaximumCharacterRule : ValidationRule
    {

        public int MaximumCharacters { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            string inputString = value as string;
            if (inputString.Length > MaximumCharacters)
            {
                return new ValidationResult(false, $"Please Enter Maximum {MaximumCharacters} Characters!");

            }
            return (new ValidationResult(true, null));

        }
    }
}
