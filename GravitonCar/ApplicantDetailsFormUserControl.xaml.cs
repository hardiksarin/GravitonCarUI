using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        CarModel model = new CarModel();


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
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            WireUpForm();
            callingForm.CoApplicantForm(model);
        }

        private void WireUpForm()
        {
            //First, Middle and Last Name

            model.applicantModel.applicant_firstname = FirstNameTextBox.Text;
            model.applicantModel.applicant_middlename = MiddleNameTextBox.Text;
            model.applicantModel.applicant_lastname = LastNameTextBox.Text;

            //Get Aquaintance

            AcquaintanceModel temp = (AcquaintanceModel)AcquaintanceComboBox.SelectedItem;
            model.applicantModel.applicant_acquaintanceid = temp.acquaintance_id;
            model.applicantModel.applicant_acquaintancename = AcquaintanceNameTextBox.Text;

            /*
            DOB - DatePicker
            Age - AgeTextBlock
            Marital Status - MaritalStatusComboBox
            Caste - CasteComboBox
            Category - CategoryComboBox
            State - StateComboBox
            District - DistrictComboBox
            Pincode - PincodeTextBox
            Address - AddressTextBlock
            Mobile Number - MobileNumberTextBox
            Office Number - OfficeNumberTextBox
            Designation - DesignationTextBox
            Education - EducationComboBox
            Employer Name - EmployerNameTextBox
            Office Address - OfficeAddressTextBlock
            Distance To NE - DistanceToNeTextBox
            Nearest Branch - NearestBranchComboBox
            */

            model.applicantModel.applicant_dob = DatePicker.SelectedDate.ToString().Split(' ').First();

            //Marital Status
            MarriedStatusModel marriedStatusModel = (MarriedStatusModel)MaritalStatusComboBox.SelectedItem;
            model.applicantModel.applicant_maritalstatusid = marriedStatusModel.maritalstatus_id;

            //Caste
            CasteModel casteModel = (CasteModel)CasteComboBox.SelectedItem;
            model.applicantModel.applicant_casteid = casteModel.caste_id;

            //Category
            CategoryModel category = (CategoryModel)CategoryComboBox.SelectedItem;
            model.applicantModel.applicant_categoryid = category.category_id;

            //State
            model.applicantModel.applicant_state = (string)StateComboBox.SelectedItem;

            /*//District
            model.applicantModel.applicant_district = (string)DistrictComboBox.SelectedItem;*/

            //Pincode
            model.applicantModel.applicant_pincode = long.Parse(PincodeTextBox.Text);

            //Address
            model.applicantModel.applicant_currentaddress = AddressTextBlock.Text;

            //Mobile Number
            model.applicantModel.applicant_mobile = long.Parse(MobileNumberTextBox.Text);

            //Office Number
            model.applicantModel.applicant_officeno = long.Parse(OfficeNumberTextBox.Text);

            //Designation
            model.applicantModel.applicant_desgination = DesignationTextBox.Text;

            //Education
            model.applicantModel.applicant_education = (string)EducationComboBox.SelectedItem;

            //Employer Name
            model.applicantModel.applicant_employername = EmployerNameTextBox.Text;

            //Office Address
            model.applicantModel.applicant_officeaddress = OfficeAddressTextBlock.Text;

            //Distance to NE
            model.applicantModel.applicant_distance = int.Parse(DistanceToNeTextBox.Text);

            //Nearest Branch
            model.applicantModel.applicant_nearestbranch = (string)NearestBranchComboBox.SelectedItem;
        }

        private int calculateAge(string current, string dob)
        {
            int age = 0;

            string[] dobArray = dob.Split('-');
            string[] todyaArray = current.Split('-');

            int dobYear = int.Parse(dobArray[2]);
            int currentYear = int.Parse(todyaArray[2]);

            if(currentYear > dobYear)
            {
                age = currentYear - dobYear;
            }
            return age;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string dob = DatePicker.SelectedDate.ToString().Split(' ').First();
            DateTime now = DateTime.Today;
            string today = now.ToString().Split(' ').First();
            int age = calculateAge(today, dob);
            AgeTextBlock.Text = age.ToString();
        }
    }
}
