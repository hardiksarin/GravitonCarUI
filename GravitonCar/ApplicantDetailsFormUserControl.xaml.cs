using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;


namespace GravitonCar
{
    /// <summary>
    /// Interaction logic for ApplicantDetailsFormUserControl.xaml
    /// </summary>
    public partial class ApplicantDetailsFormUserControl : UserControl, INotifyPropertyChanged, IValidateError
    {
        private string _applicant_firstname;
        private string _applicant_lastname;
        private string _applicant_middlename;
        private string _applicant_dob;
        private string _applicant_acquaintancename;
        private string _applicant_state;
        private int _applicant_distance;
        private string _applicant_district;
        private string _applicant_currentaddress;
        private string _applicant_pincode;
        private string _applicant_mobile;
        private string applicant_officeno;
        private string _applicant_desgination;
        private string _applicant_education;
        private string _applicant_employername;
        private string _applicant_nearestbranch;
        private string _applicant_officeaddress;

        public string ApplicantFirstname
        {
            get { return _applicant_firstname; }
            set { _applicant_firstname = value;
                OnPropertyChanged("ApplicantFirstname");
            }
        }

        public string ApplicantLastname
        {
            get { return _applicant_lastname; }
            set { _applicant_lastname = value;
                OnPropertyChanged("ApplicantLastname");
            }
        }

        public string ApplicantMiddlename
        {
            get { return _applicant_middlename; }
            set { _applicant_middlename = value;
                OnPropertyChanged("ApplicantMiddlename");
            }
        }


        public string ApplicantAcquaintance
        {
            get { return _applicant_acquaintancename; }
            set { _applicant_acquaintancename = value;
                OnPropertyChanged("ApplicantAcquaintance");
            }
        }

        public string ApplicantDob
        {
            get { return _applicant_dob; }
            set { _applicant_dob = value;
                OnPropertyChanged("ApplicantDob");
            }
        }

        public string ApplicantState
        {
            get { return _applicant_state; }
            set { _applicant_state = value;
                OnPropertyChanged("ApplicantState");
            }
        }

        public string ApplicantDistrict
        {
            get { return _applicant_district; }
            set { _applicant_district = value;
                OnPropertyChanged("ApplicantDistrict");
            }
        }

        public string ApplicantCurrentAddress
        {
            get { return _applicant_currentaddress; }
            set { _applicant_currentaddress = value;
                OnPropertyChanged("ApplicantCurrentAddress");
            }
        }

        public string ApplicantPincode
        {
            get { return _applicant_pincode; }
            set { _applicant_pincode = value;
                OnPropertyChanged("ApplicantPincode");
            }
        }

        public string ApplicantMobile
        {
            get { return _applicant_mobile; }
            set { _applicant_mobile = value;
                OnPropertyChanged("ApplicantMobile");
            }
        }

        public string ApplicantOfficeNo
        {
            get { return applicant_officeno; }
            set { applicant_officeno = value;
                OnPropertyChanged("ApplicantOfficeNo");
            }
        }

        public string ApplicantDesignation
        {
            get { return _applicant_desgination; }
            set { _applicant_desgination = value;
                OnPropertyChanged("ApplicantDesignation");
            }
        }

        public string ApplicantEducation
        {
            get { return _applicant_education; }
            set { _applicant_education = value;
                OnPropertyChanged("ApplicantEducation");
            }
        }

        public string ApplicantEmployer
        {
            get { return _applicant_employername; }
            set { _applicant_employername = value;
                OnPropertyChanged("ApplicantEmployer");
            }
        }

        public string ApplicantOfficeAddress
        {
            get { return _applicant_officeaddress; }
            set { _applicant_officeaddress = value;
                OnPropertyChanged("ApplicantOfficeAddress");
            }
        }

        public string ApplicantNearestBranch
        {
            get { return _applicant_nearestbranch; }
            set { _applicant_nearestbranch = value;
                OnPropertyChanged("ApplicantNearestBranch");
            }
        }

        public int ApplicantDistance
        {
            get { return _applicant_distance; }
            set { _applicant_distance = value;
                OnPropertyChanged("ApplicantDistance");
            }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        IScreenRequester callingForm;
        public static IValidateError errorForm { get; set; }
        /*List<MarriedStatusModel> maritalStatusList = new List<MarriedStatusModel>();
        List<AcquaintanceModel> acquaintanceList = new List<AcquaintanceModel>();
        List<CasteModel> casteList = new List<CasteModel>();
        List<CategoryModel> categoryList = new List<CategoryModel>();
        List<string> stateList = new List<string>() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" };
        List<string> educationList = new List<string>() { "Postgraduate ", "Undergraduate", "Higher secondary", "Matriculation"};
        List<string> branchesList = new List<string>() { "Jaipur Office " };*/
        CarModel model = new CarModel();
        JObject jsonDistrict;

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicantDetailsFormUserControl(IScreenRequester caller)
        {
            DataContext = this;
            InitializeComponent();
            errorForm = this;
            callingForm = caller;
            LoadListData();
            WireUpList();
        }

        private void LoadListData()
        {
            /*maritalStatusList = GlobalConfig.Connection.GetMarried_All();
            acquaintanceList = GlobalConfig.Connection.GetAcquaintance_All();
            casteList = GlobalConfig.Connection.GetCaste_All();
            categoryList = GlobalConfig.Connection.GetCategory_All();*/
            jsonDistrict = JObject.Parse(GlobalConfig.json);
        }

        private void WireUpList()
        {
            MaritalStatusComboBox.ItemsSource = null;
            MaritalStatusComboBox.ItemsSource = Search.maritalStatusList;
            MaritalStatusComboBox.DisplayMemberPath = "maritalstatus_name";

            AcquaintanceComboBox.ItemsSource = null;
            AcquaintanceComboBox.ItemsSource = Search.acquaintanceList;
            AcquaintanceComboBox.DisplayMemberPath = "acquaintance_name";

            CasteComboBox.ItemsSource = null;
            CasteComboBox.ItemsSource = Search.casteList;
            CasteComboBox.DisplayMemberPath = "caste_name";

            CategoryComboBox.ItemsSource = null;
            CategoryComboBox.ItemsSource = Search.categoryList;
            CategoryComboBox.DisplayMemberPath = "category_name";

            StateComboBox.ItemsSource = null;
            StateComboBox.ItemsSource = Search.stateList;

            EducationComboBox.ItemsSource = null;
            EducationComboBox.ItemsSource = Search.educationList;

            NearestBranchComboBox.ItemsSource = null;
            NearestBranchComboBox.ItemsSource = Search.branchesList;

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
            if (ValidateApplicantForm())
            {
                //WireUpForm();
                this.Dispatcher.Invoke(() =>
                {
                    WireUpForm();
                    //wireFormThread.Start();
                });
                callingForm.CoApplicantForm(model);
            }
            else
            {
                SnackbarFive.IsActive = true;
                SnackbarFive.MessageQueue.Enqueue("Please Complete The Form To Proceed", null,
                    null,
                    null,
                    false,
                    true,
                    TimeSpan.FromSeconds(5));
            }
        }

        private void WireUpForm()
        {
            //First, Middle and Last Name
      
            model.applicantModel.applicant_firstname = ApplicantFirstname;
            if (MiddleNameTextBox.Text.Length != 0)
            {
                model.applicantModel.applicant_middlename = ApplicantMiddlename;
            }
            else
            {
                model.applicantModel.applicant_middlename = "";
            }
            model.applicantModel.applicant_lastname = ApplicantLastname;

            //Get Aquaintance

            AcquaintanceModel temp = (AcquaintanceModel)AcquaintanceComboBox.SelectedItem;
            model.applicantModel.applicant_acquaintanceid = temp.acquaintance_id;
            model.applicantModel.applicant_acquaintancename = ApplicantAcquaintance;

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

            //District
            model.applicantModel.applicant_district = (string)DistrictComboBox.SelectedItem;

            //Pincode
            model.applicantModel.applicant_pincode = ApplicantPincode;

            //Address
            model.applicantModel.applicant_currentaddress = ApplicantCurrentAddress;

            //Mobile Number
            model.applicantModel.applicant_mobile = ApplicantMobile;

            //Office Number
            model.applicantModel.applicant_officeno = ApplicantOfficeNo;

            //Designation
            model.applicantModel.applicant_desgination = ApplicantDesignation;

            //Education
            model.applicantModel.applicant_education = (string)EducationComboBox.SelectedItem;

            //Employer Name
            model.applicantModel.applicant_employername = ApplicantEmployer;

            //Office Address
            model.applicantModel.applicant_officeaddress = ApplicantOfficeAddress;

            //Distance to NE
            model.applicantModel.applicant_distance = ApplicantDistance;

            //Nearest Branch
            model.applicantModel.applicant_nearestbranch = (string)NearestBranchComboBox.SelectedItem;
        }

        private bool ValidateApplicantForm()
        {
            bool output = true;

            if(ApplicantFirstname == null)
            {
                return false;
            }
            if(ApplicantLastname == null)
            {
                return false;
            }
            if(AcquaintanceComboBox.SelectedItem == null)
            {
                return false;
            }
            if(ApplicantAcquaintance == null)
            {
                return false;
            }
            if(DatePicker.SelectedDate == null)
            {
                return false;
            }
            if(MaritalStatusComboBox.SelectedItem == null)
            {
                return false;
            }
            if(CasteComboBox.SelectedItem == null)
            {
                return false;
            }
            if(CategoryComboBox.SelectedItem == null)
            {
                return false;
            }
            if(StateComboBox.SelectedItem == null)
            {
                return false;
            }
            if(DistrictComboBox.SelectedItem == null)
            {
                return false;
            }
            if(ApplicantPincode == null)
            {
                return false;
            }
            if(ApplicantCurrentAddress == null)
            {
                return false;
            }
            if(ApplicantMobile == null)
            {
                return false;
            }
            if(ApplicantOfficeNo == null)
            {
                return false;
            }
            if(ApplicantDesignation == null)
            {
                return false;
            }
            if(EducationComboBox.SelectedItem == null)
            {
                return false;
            }
            if(ApplicantEmployer == null)
            {
                return false;
            }
            if(ApplicantOfficeAddress == null)
            {
                return false;
            }
            if(ApplicantDistance == 0)
            {
                return false;
            }
            if(NearestBranchComboBox.SelectedItem == null)
            {
                return false;
            }

            return output;
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

        public void DisableButton()
        {
            NextButton.IsEnabled = false;
        }

        public void EnableButton()
        {
            NextButton.IsEnabled = true;
        }

        private void StateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string state = (string)StateComboBox.SelectedItem;
            List<string> temp = new List<string>();
            var obj1 = jsonDistrict[state];
            int x = obj1.Count();

            for (int i = 0; i < x; i++)
            {
                var obj = jsonDistrict[state][i];
                temp.Add(obj.ToString());
            }
            DistrictComboBox.ItemsSource = null;
            DistrictComboBox.ItemsSource = temp;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nYour changes will be removed!", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                callingForm.SearchScreen();
            }
        }
    }
}
