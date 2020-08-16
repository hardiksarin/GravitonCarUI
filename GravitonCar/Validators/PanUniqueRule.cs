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


            List<DocumentModel> documents = new List<DocumentModel>();

            public PanUniqueRule()
            {
                documents = GlobalConfig.Connection.GetDocument_All();
            }
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string v = value as string;

                foreach (DocumentModel document in documents)
                {
                    if (document.document_pan == v)
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
