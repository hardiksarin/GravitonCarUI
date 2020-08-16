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
    class PanUniqueRule : ValidationRule
    {


            List<ApplicantModel> applicants = new List<ApplicantModel>();

            public PanUniqueRule()
            {
                applicants = GlobalConfig.Connection.GetApplicant_All();
            }
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string v = value as string;

                foreach (ApplicantModel applicant in applicants)
                {
                    if (applicant.applicant_pan == v)
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
