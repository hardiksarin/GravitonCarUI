using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GravitonCar
{
    /// <summary>
    /// Interaction logic for ApplicantDetailsFormUserControl.xaml
    /// </summary>
    public partial class ApplicantDetailsFormUserControl : UserControl
    {
        IScreenRequester callingForm;
        List<MarriedStatusModel> maritalStatusList = new List<MarriedStatusModel>();
        List<AcquaintanceModel> acquaintanceList = new List<AcquaintanceModel>();
        List<CasteModel> casteList = new List<CasteModel>();
        List<CategoryModel> categoryList = new List<CategoryModel>();
        List<string> stateList = new List<string>() { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttarakhand", "Uttar Pradesh", "West Bengal", "Andaman and Nicobar Islands", "Chandigarh", "Dadra and Nagar Haveli", "Daman and Diu", "Delhi", "Lakshadweep", "Puducherry" };
        List<string> educationList = new List<string>() { "Postgraduate ", "Undergraduate", "Higher secondary", "Matriculation"};
        List<string> branchesList = new List<string>() { "Jaipur Office " };


        public ApplicantDetailsFormUserControl(IScreenRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            LoadListData();
            WireUpList();
        }

        private void LoadListData()
        {
            maritalStatusList = GlobalConfig.Connection.GetMarried_All();
            acquaintanceList = GlobalConfig.Connection.GetAcquaintance_All();
            casteList = GlobalConfig.Connection.GetCaste_All();
            categoryList = GlobalConfig.Connection.GetCategory_All();

        }

        private void WireUpList()
        {
            MaritalStatusComboBox.ItemsSource = null;
            MaritalStatusComboBox.ItemsSource = maritalStatusList;
            MaritalStatusComboBox.DisplayMemberPath = "maritalstatus_name";

            AcquaintanceComboBox.ItemsSource = null;
            AcquaintanceComboBox.ItemsSource = acquaintanceList;
            AcquaintanceComboBox.DisplayMemberPath = "acquaintance_name";

            CasteComboBox.ItemsSource = null;
            CasteComboBox.ItemsSource = casteList;
            CasteComboBox.DisplayMemberPath = "caste_name";

            CategoryComboBox.ItemsSource = null;
            CategoryComboBox.ItemsSource = categoryList;
            CategoryComboBox.DisplayMemberPath = "category_name";

            StateComboBox.ItemsSource = null;
            StateComboBox.ItemsSource = stateList;

            EducationComboBox.ItemsSource = null;
            EducationComboBox.ItemsSource = educationList;

            NearestBranchComboBox.ItemsSource = null;
            NearestBranchComboBox.ItemsSource = branchesList;



        }
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                myscrollview.ScrollToHome();

                myscrollview.UpdateLayout();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "doc");
                }

            }
            finally
            {
                this.IsEnabled = true;
            }

        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            callingForm.CoApplicantForm();
            




        }







    }
}
