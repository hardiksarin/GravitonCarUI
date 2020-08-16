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
    class AadharUniqueRule : ValidationRule
    {
        List<ApplicantModel> applicants = new List<ApplicantModel>();

        public AadharUniqueRule()
        {
            applicants = GlobalConfig.Connection.GetApplicant_All();
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;

            foreach (ApplicantModel applicant in applicants)
            {
                if (applicant.applicant_aadhar == v)
                {
                    ApplicantDetailsFormUserControl.errorForm.DisableButton();

                    return new ValidationResult(false, $"Alert: Aadhar Already Exist");
                }
                

            }

            ApplicantDetailsFormUserControl.errorForm.EnableButton();

            return new ValidationResult(true, null);
        }
    }
}
