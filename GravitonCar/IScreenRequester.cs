using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar
{
    public interface IScreenRequester
    {
        /// <summary>
        /// Clears Grid and Navigates to Applicant Form
        /// </summary>
        void ApplicantForm();
        /// <summary>
        /// Navigates to Co-Applicant Form
        /// </summary>
        /// <param name="model"></param>
        void CoApplicantForm(CarModel model);
        /// <summary>
        /// Navigates to Financial Form
        /// </summary>
        /// <param name="model"></param>
        void FinancialScreen(CarModel model);
        /// <summary>
        /// Removes Co-Applicant Form
        /// </summary>
        /// <param name="control"></param>
        void RemoveCoApplicantScreen(UserControl control);
        /// <summary>
        /// Removes Financial Form
        /// </summary>
        /// <param name="control"></param>
        void RemoveFinancialScreen(UserControl control);
        /// <summary>
        /// Navigates to Preview Screen
        /// </summary>
        /// <param name="model"></param>
        void PreviewScreen(CarModel model);
        /// <summary>
        /// Navigates to Display Screen
        /// </summary>
        /// <param name="model"></param>
        void DisplayScreen(CarModel model);
        /// <summary>
        /// Writes File path to path.txt
        /// </summary>
        /// <param name="path"></param>
        void SetSystemPath(string path);
        /// <summary>
        /// Navigates to Search Screen
        /// </summary>
        void SearchScreen();
        /// <summary>
        /// Navigates To New User Form
        /// </summary>
        void NewUser();
        /// <summary>
        /// Navigates To Admin Panel
        /// </summary>
        void AdminPanel();
    }
}
