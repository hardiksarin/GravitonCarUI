using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar
{
    public interface IScreenRequester
    {
        void ApplicantForm();
        void CoApplicantForm(CarModel model);
        void FinancialScreen(CarModel model);
        void RemoveCoApplicantScreen(UserControl control);
        void RemoveFinancialScreen(UserControl control);
        void PreviewScreen(CarModel model);
    }
}
