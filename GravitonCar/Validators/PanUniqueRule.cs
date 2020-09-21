using System.Globalization;
using System.Windows.Controls;

using System;
using System.Text;
using System.Linq;
using GravitonCarLibrary.Models;
using System.Collections.Generic;
using GravitonCarLibrary;

namespace GravitonCar.Validators
{
  public  class PanUniqueRule : ValidationRule
    {


            List<string> panList = new List<string>();

            public PanUniqueRule()
            {
            panList = Search.panList;
            }
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string v = value as string;

                foreach (string pan in panList)
                {
                    if (pan == v)
                    {
                        ApplicantDetailsFormUserControl.errorForm.DisableButton();

                        return new ValidationResult(false, $"Alert: Pan Number Already Exist");
                    }


                }

                ApplicantDetailsFormUserControl.errorForm.EnableButton();

                return new ValidationResult(true, null);
            }
        
    }

}
