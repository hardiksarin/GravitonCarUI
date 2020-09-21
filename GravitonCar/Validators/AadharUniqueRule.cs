﻿using System.Globalization;
using System.Windows.Controls;

using System;
using System.Text;
using System.Linq;
using GravitonCarLibrary.Models;
using System.Collections.Generic;
using GravitonCarLibrary;

namespace GravitonCar.Validators
{
   public class AadharUniqueRule : ValidationRule
    {
        //List<DocumentModel> documents = new List<DocumentModel>();
        List<string> aadharList = new List<string>();

        public AadharUniqueRule()
        {
            aadharList = Search.aadharList;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string;

            foreach (string aadhar in aadharList)
            {
                if (aadhar == v)
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
