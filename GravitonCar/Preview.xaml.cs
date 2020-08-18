using GravitonCar.Models;
using GravitonCar.Validators;
using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Preview.xaml
    /// </summary>
    public partial class Preview : UserControl, INotifyPropertyChanged, IValidateError
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

        private string _gurantor_firstname;
        private string _gurantor_middlename;
        private string _gurantor_lastname;
        private string _gurantor_currentaddress;
        private string _gurantor_mobile;
        private string _gurantor_relation;

        private string _document_aadhar;
        private string _document_pan;
        private int _document_cibil;
        private string _document_optional;
        private string _account_bankname;
        private string _account_ifsc;
        private string _account_number;
        private int _account_inhandsalary;
        private string _loan_bankname;
        private double _loan_amount;
        private double _loan_emi;

        public string ApplicantFirstname
        {
            get { return _applicant_firstname; }
            set
            {
                _applicant_firstname = value;
                OnPropertyChanged("ApplicantFirstname");
            }
        }

        public string ApplicantLastname
        {
            get { return _applicant_lastname; }
            set
            {
                _applicant_lastname = value;
                OnPropertyChanged("ApplicantLastname");
            }
        }

        public string ApplicantMiddlename
        {
            get { return _applicant_middlename; }
            set
            {
                _applicant_middlename = value;
                OnPropertyChanged("ApplicantMiddlename");
            }
        }


        public string ApplicantAcquaintance
        {
            get { return _applicant_acquaintancename; }
            set
            {
                _applicant_acquaintancename = value;
                OnPropertyChanged("ApplicantAcquaintance");
            }
        }

        public string ApplicantDob
        {
            get { return _applicant_dob; }
            set
            {
                _applicant_dob = value;
                OnPropertyChanged("ApplicantDob");
            }
        }

        public string ApplicantState
        {
            get { return _applicant_state; }
            set
            {
                _applicant_state = value;
                OnPropertyChanged("ApplicantState");
            }
        }

        public string ApplicantDistrict
        {
            get { return _applicant_district; }
            set
            {
                _applicant_district = value;
                OnPropertyChanged("ApplicantDistrict");
            }
        }

        public string ApplicantCurrentAddress
        {
            get { return _applicant_currentaddress; }
            set
            {
                _applicant_currentaddress = value;
                OnPropertyChanged("ApplicantCurrentAddress");
            }
        }

        public string ApplicantPincode
        {
            get { return _applicant_pincode; }
            set
            {
                _applicant_pincode = value;
                OnPropertyChanged("ApplicantPincode");
            }
        }

        public string ApplicantMobile
        {
            get { return _applicant_mobile; }
            set
            {
                _applicant_mobile = value;
                OnPropertyChanged("ApplicantMobile");
            }
        }

        public string ApplicantOfficeNo
        {
            get { return applicant_officeno; }
            set
            {
                applicant_officeno = value;
                OnPropertyChanged("ApplicantOfficeNo");
            }
        }

        public string ApplicantDesignation
        {
            get { return _applicant_desgination; }
            set
            {
                _applicant_desgination = value;
                OnPropertyChanged("ApplicantDesignation");
            }
        }

        public string ApplicantEducation
        {
            get { return _applicant_education; }
            set
            {
                _applicant_education = value;
                OnPropertyChanged("ApplicantEducation");
            }
        }

        public string ApplicantEmployer
        {
            get { return _applicant_employername; }
            set
            {
                _applicant_employername = value;
                OnPropertyChanged("ApplicantEmployer");
            }
        }

        public string ApplicantOfficeAddress
        {
            get { return _applicant_officeaddress; }
            set
            {
                _applicant_officeaddress = value;
                OnPropertyChanged("ApplicantOfficeAddress");
            }
        }

        public string ApplicantNearestBranch
        {
            get { return _applicant_nearestbranch; }
            set
            {
                _applicant_nearestbranch = value;
                OnPropertyChanged("ApplicantNearestBranch");
            }
        }

        public int ApplicantDistance
        {
            get { return _applicant_distance; }
            set
            {
                _applicant_distance = value;
                OnPropertyChanged("ApplicantDistance");
            }
        }

        public string GurantorFirstname
        {
            get { return _gurantor_firstname; }
            set
            {
                _gurantor_firstname = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorMiddlename
        {
            get { return _gurantor_middlename; }
            set
            {
                _gurantor_middlename = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorLastname
        {
            get { return _gurantor_lastname; }
            set
            {
                _gurantor_lastname = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorCurrentAddress
        {
            get { return _gurantor_currentaddress; }
            set
            {
                _gurantor_currentaddress = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorMobile
        {
            get { return _gurantor_mobile; }
            set
            {
                _gurantor_mobile = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorRelation
        {
            get { return _gurantor_relation; }
            set
            {
                _gurantor_relation = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string DocumentAadhar
        {
            get { return _document_aadhar; }
            set
            {
                _document_aadhar = value;
                OnPropertyChanged("DocumentAadhar");
            }
        }


        public string DocumentPan
        {
            get { return _document_pan; }
            set
            {
                _document_pan = value;
                OnPropertyChanged("DocumentPan");
            }
        }


        public int DocumentCibil
        {
            get { return _document_cibil; }
            set
            {
                _document_cibil = value;
                OnPropertyChanged("DocumentCibil");
            }
        }


        public string DocumentOptional
        {
            get { return _document_optional; }
            set
            {
                _document_optional = value;
                OnPropertyChanged("DocumentOptional");
            }
        }


        public string AccountBankName
        {
            get { return _account_bankname; }
            set
            {
                _account_bankname = value;
                OnPropertyChanged("AccountBankName");
            }
        }


        public string AccountIfsc
        {
            get { return _account_ifsc; }
            set
            {
                _account_ifsc = value;
                OnPropertyChanged("AccountIfsc");
            }
        }


        public string AccountNumber
        {
            get { return _account_number; }
            set
            {
                _account_number = value;
                OnPropertyChanged("AccountNumber");
            }
        }


        public int AccountSalary
        {
            get { return _account_inhandsalary; }
            set
            {
                _account_inhandsalary = value;
                OnPropertyChanged("AccountSalary");
            }
        }

        public string LoanBankName
        {
            get { return _loan_bankname; }
            set
            {
                _loan_bankname = value;
                OnPropertyChanged("LoanBankName");
            }
        }


        public double LoanAmount
        {
            get { return _loan_amount; }
            set
            {
                _loan_amount = value;
                OnPropertyChanged("LoanAmount");
            }
        }


        public double LoanEmi
        {
            get { return _loan_emi; }
            set
            {
                _loan_emi = value;
                OnPropertyChanged("LoanEmi");
            }
        }








        CarModel model = new CarModel();
        private List<MarriedStatusModel> maritalStatusList = new List<MarriedStatusModel>();
        private List<AcquaintanceModel> acquaintanceList = new List<AcquaintanceModel>();
        private List<CasteModel> casteList = new List<CasteModel>();
        private List<CategoryModel> categoryList = new List<CategoryModel>();
        List<string> stateList = new List<string>() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" };
        private List<string> educationList = new List<string>() { "Postgraduate ", "Undergraduate", "Higher secondary", "Matriculation" };
        private List<string> branchesList = new List<string>() { "Jaipur Office " };
        private List<GurantorTypeModel> gurantorType = new List<GurantorTypeModel>();
        private List<LoanTypeModel> loanTypes = new List<LoanTypeModel>();
        private List<DocumentTypeModel> documentModels = new List<DocumentTypeModel>();
        List<LoanModel> loanModels = new List<LoanModel>();
        JObject jsonDistrict;
        int i = 0;
        List<NewLoanModel> existingLoans = new List<NewLoanModel>();
        IScreenRequester callingForm;

        public event PropertyChangedEventHandler PropertyChanged;

        public Preview(IScreenRequester caller, CarModel carModel)
        {
            DataContext = this;
            InitializeComponent();
            ApplicantDetailsFormUserControl.errorForm = this;
            callingForm = caller;
            model = carModel;
            LoadListData();
            WireUpLists();
            WireUpPreviewForm();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadListData()
        {
            maritalStatusList = GlobalConfig.Connection.GetMarried_All();
            acquaintanceList = GlobalConfig.Connection.GetAcquaintance_All();
            casteList = GlobalConfig.Connection.GetCaste_All();
            categoryList = GlobalConfig.Connection.GetCategory_All();

            gurantorType = GlobalConfig.Connection.GetGurantorType_All();

            loanTypes = GlobalConfig.Connection.GetLoanType_All();
            documentModels = GlobalConfig.Connection.GetDocumentType_All();

            jsonDistrict = JObject.Parse(GlobalConfig.json);
        }

        private void WireUpLists()
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

            GurantorComboBox.ItemsSource = null;
            GurantorComboBox.ItemsSource = gurantorType;
            GurantorComboBox.DisplayMemberPath = "gurantortype_name";

            OptionalIdTypeComboBox.ItemsSource = null;
            OptionalIdTypeComboBox.ItemsSource = documentModels;

            OptionalIdTypeComboBox.DisplayMemberPath = "documenttype_name";
        }

        private void WireUpPreviewForm()
        {
            WireUpApplicantForm();
            WireUpGurantorForm();
            WireUpFinancialForm();
        }

        ComboBox addLoanTypeDynamic(int i, LoanModel loan)
        {
            ComboBox LoanType = new ComboBox();
            LoanType.Name = $"LoanNameTextbox{i}";                                //"LoanNameTextbox" + i.ToString();
            LoanType.Width = 200;
            LoanType.ItemsSource = loanTypes;
            LoanType.DisplayMemberPath = "loantype_name";
            LoanType.SelectedIndex = loan.loan_type - 1;
            return LoanType;
        }

        TextBox addLoanBankNameDynamic(int i, LoanModel loan)
        {
            TextBox LoanBankName = new TextBox();
            /*Binding binding = new Binding("LoanBankName");
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            binding.Mode = BindingMode.TwoWay;
            MinimumCharacterRule mcr = new MinimumCharacterRule();
            mcr.MinimumCharacters = 3;
            binding.ValidationRules.Add(mcr);
            LoanBankName.SetBinding(TextBox.TextProperty, binding);*/
            LoanBankName.Name = $"LoanBankNameTextbox{i}";                        //"LoanBankNameTextbox" + i.ToString();
            LoanBankName.Margin = new Thickness(10);
            LoanBankName.Width = 200;
            LoanBankName.Text = loan.loan_bankname;
            return LoanBankName;
        }

        TextBox addLoanAmountDynamic(int i, LoanModel loan)
        {
            TextBox LoanAmount = new TextBox();
            /*Binding binding = new Binding("LoanAmount");
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            binding.Mode = BindingMode.TwoWay;
            OnlyNumericRule onr = new OnlyNumericRule();
            binding.ValidationRules.Add(onr);
            LoanAmount.SetBinding(TextBox.TextProperty, binding);*/
            LoanAmount.Name = $"LoanLoanAmountTextbox{i}";                        //"LoanLoanAmountTextbox" + i.ToString();
            LoanAmount.Margin = new Thickness(10);
            LoanAmount.Width = 200;
            LoanAmount.Text = loan.loan_amount.ToString();
            return LoanAmount;
        }

        TextBox addLoanEmiAmountDynamic(int i, LoanModel loan)
        {
            TextBox LoanEmiAmount = new TextBox();
            /*Binding binding = new Binding("LoanEmi");
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            binding.Mode = BindingMode.TwoWay;
            OnlyNumericRule onr = new OnlyNumericRule();
            binding.ValidationRules.Add(onr);
            LoanEmiAmount.SetBinding(TextBox.TextProperty, binding);*/
            LoanEmiAmount.Name = $"LoanEmiAmountTextbox{i}";                       //"LoanEmiAmountTextbox" + i.ToString();
            LoanEmiAmount.Margin = new Thickness(10);
            LoanEmiAmount.Width = 200;
            LoanEmiAmount.Text = loan.loan_emi.ToString();
            return LoanEmiAmount;
        }

        Expander addExpanderPannelDynamic(int i, LoanModel loan)
        {
            Expander LoanExpander = new Expander();
            LoanExpander.Name = "LoanExpander" + i.ToString();
            WrapPanel s = addLoanDetailsDynamic(i, loan);
            LoanExpander.Header = "Loan Number :" + (i + 1).ToString(); ;
            LoanExpander.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanExpander.FontSize = 20;
            LoanExpander.Content = s;
            LoanExpander.FontWeight = FontWeights.Light;

            return LoanExpander;
        }

        WrapPanel addLoanDetailsDynamic(int i, LoanModel loan)
        {
            WrapPanel LoanDetails = new WrapPanel();
            LoanDetails.Orientation = Orientation.Vertical;
            LoanDetails.Background = new SolidColorBrush(Colors.WhiteSmoke);


            LoanDetails.Name = "LoanBankNameTextbox" + i.ToString();

            Label LoanTypeLabel = new Label();
            ComboBox LoanType = addLoanTypeDynamic(i, loan);
            Label LoanBankNameLabel = new Label();
            TextBox LoanBankName = addLoanBankNameDynamic(i, loan);
            Label LoanAmountLabel = new Label();
            TextBox LoanAmount = addLoanAmountDynamic(i, loan);
            Label LoanEmiAmountLabel = new Label();
            TextBox LoanEmiAmount = addLoanEmiAmountDynamic(i, loan);


            LoanTypeLabel.Content = "Loan Name";
            LoanBankNameLabel.Content = "Bank Name";
            LoanAmountLabel.Content = "Loan Amount";
            LoanEmiAmountLabel.Content = "Loan EMI";



            LoanTypeLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanBankNameLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanAmountLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanEmiAmountLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);


            LoanTypeLabel.FontSize = 20;
            LoanBankNameLabel.FontSize = 20;
            LoanAmountLabel.FontSize = 20;
            LoanEmiAmountLabel.FontSize = 20;

            LoanTypeLabel.FontWeight = FontWeights.Light;
            LoanBankNameLabel.FontWeight = FontWeights.Light;
            LoanAmountLabel.FontWeight = FontWeights.Light;
            LoanEmiAmountLabel.FontWeight = FontWeights.Light;

            LoanType.Margin = new Thickness(5);
            LoanBankName.Margin = new Thickness(5);
            LoanAmount.Margin = new Thickness(5);
            LoanEmiAmount.Margin = new Thickness(5);
            LoanTypeLabel.Margin = new Thickness(5);
            LoanBankNameLabel.Margin = new Thickness(5);
            LoanAmountLabel.Margin = new Thickness(5);
            LoanEmiAmountLabel.Margin = new Thickness(5);



            LoanDetails.Children.Add(LoanTypeLabel);
            LoanDetails.Children.Add(LoanType);
            this.Dynamic.RegisterName(LoanType.Name, LoanType);
            LoanDetails.Children.Add(LoanBankNameLabel);
            LoanDetails.Children.Add(LoanBankName);
            this.Dynamic.RegisterName(LoanBankName.Name, LoanBankName);
            LoanDetails.Children.Add(LoanAmountLabel);
            LoanDetails.Children.Add(LoanAmount);
            this.Dynamic.RegisterName(LoanAmount.Name, LoanAmount);
            LoanDetails.Children.Add(LoanEmiAmountLabel);
            LoanDetails.Children.Add(LoanEmiAmount);
            this.Dynamic.RegisterName(LoanEmiAmount.Name, LoanEmiAmount);


            return LoanDetails;

        }

        private int calculateAge(string current, string dob)
        {
            int age = 0;
            string[] dobArray;
            if (dob.Length < 13)
            {
                dobArray = dob.Split('-');
            }
            else
            {
                string t = dob.Split(' ').First();
                dobArray = t.Split('/');
            }

            string[] todyaArray = current.Split('-');

            int dobYear = int.Parse(dobArray[2]);
            int currentYear = int.Parse(todyaArray[2]);

            if (currentYear > dobYear)
            {
                age = currentYear - dobYear;
            }
            return age;
        }

        private void createLoan(LoanModel loanModel)
        {
            Expander expander = addExpanderPannelDynamic(i, loanModel);
            this.Dynamic.Children.Add(expander);
            this.Dynamic.RegisterName(expander.Name, expander);
            // Add Loan Model
            NewLoanModel loan = new NewLoanModel();
            /*
             * Loan Number - int
             * Loan Expander ID Name - string
             * Loan Type {ComboBox} - string
             * Bank name - string
             * Loan Amount - double
             * Loan Emi Amount - double
            */
            loan.LoanNumber = i + 1;
            loan.LoanExpanderName = $"LoanExpander{i}";
            loan.LoanTypeLabel.Name = $"LoanNameTextbox{i}";
            loan.LoanBankNameLabel.Name = $"LoanBankNameTextbox{i}";
            loan.LoanAmountLabel.Name = $"LoanLoanAmountTextbox{i}";
            loan.LoanEmiAmountLabel.Name = $"LoanEmiAmountTextbox{i}";
            existingLoans.Add(loan);
            i++;
        }

        private void WireUpApplicantForm()
        {
            //First, Middle and Last Name

            FirstNameTextBox.Text = model.applicantModel.applicant_firstname;
            if (model.applicantModel.applicant_middlename != null)
            {
                MiddleNameTextBox.Text = model.applicantModel.applicant_middlename; 
            }
            LastNameTextBox.Text = model.applicantModel.applicant_lastname;

            //Get Aquaintance
            foreach (AcquaintanceModel acquaintance in acquaintanceList)
            {
                if(acquaintance.acquaintance_id == model.applicantModel.applicant_acquaintanceid)
                {
                    AcquaintanceComboBox.SelectedItem = acquaintance;
                }
            }

            AcquaintanceNameTextBox.Text = model.applicantModel.applicant_acquaintancename;

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
            Distance To NE - DistanceToNeTextBoxm,
            Nearest Branch - NearestBranchComboBox
            */

            string dobTemp = model.applicantModel.applicant_dob;
            DateTime dobDate = Convert.ToDateTime(dobTemp);
            DatePicker.SelectedDate = dobDate;

            string today = DateTime.Today.ToString().Split(' ').First();
            int a = calculateAge(today , dobTemp);

            AgeTextBlock.Text = a.ToString();

            //Marital Status
            foreach (MarriedStatusModel married in maritalStatusList)
            {
                if(married.maritalstatus_id == model.applicantModel.applicant_maritalstatusid)
                {
                    MaritalStatusComboBox.SelectedItem = married;
                }
            }

            //Caste
            foreach (CasteModel caste in casteList)
            {
                if(caste.caste_id == model.applicantModel.applicant_casteid)
                {
                    CasteComboBox.SelectedItem = caste;
                }
            }

            //Category
            foreach (CategoryModel category in categoryList)
            {
                if(category.category_id == model.applicantModel.applicant_categoryid)
                {
                    CategoryComboBox.SelectedItem = category;
                }
            }

            //State
            StateComboBox.SelectedItem = model.applicantModel.applicant_state;

            //District
            DistrictComboBox.SelectedItem = model.applicantModel.applicant_district;

            //Pincode
            PincodeTextBox.Text = model.applicantModel.applicant_pincode;

            //Address
            AddressTextBlock.Text = model.applicantModel.applicant_currentaddress;

            //Mobile Number
            MobileNumberTextBox.Text = model.applicantModel.applicant_mobile;

            //Office Number
            OfficeNumberTextBox.Text = model.applicantModel.applicant_officeno;

            //Designation
            DesignationTextBox.Text = model.applicantModel.applicant_desgination;

            //Education
            EducationComboBox.SelectedItem = model.applicantModel.applicant_education;

            //Employer Name
            EmployerNameTextBox.Text = model.applicantModel.applicant_employername;

            //Office Address
            OfficeAddressTextBlock.Text = model.applicantModel.applicant_officeaddress;

            //Distance to NE
            DistanceToNeTextBox.Text = model.applicantModel.applicant_distance.ToString();

            //Nearest Branch
            NearestBranchComboBox.SelectedItem = model.applicantModel.applicant_nearestbranch;
        }

        private void WireUpGurantorForm()
        {
            //Co Applicant or Gurantor
            foreach (GurantorTypeModel gurantor in gurantorType)
            {
                if (model.gurantorModel.gurantortype_id == gurantor.gurantortype_id)
                {
                    GurantorComboBox.SelectedItem = gurantor;
                }
            }

            //First, Middle and Last Name
            FirstNameApplicantTextBox.Text = model.gurantorModel.gurantor_firstname;
            if (model.gurantorModel.gurantor_middlename != null)
            {
                MiddleNameApplicantTextBox.Text = model.gurantorModel.gurantor_middlename; 
            }
            LastNameApplicantTextBox.Text = model.gurantorModel.gurantor_lastname;

            //Mobile
            MobilNumberApplicantTextBox.Text = model.gurantorModel.gurantor_mobile;

            //Relationship
            RelationshipApplicantTextBox.Text = model.gurantorModel.gurantor_relation;

            //Office Address
            OfficeAddressApplicantTextBlock.Text = model.gurantorModel.gurantor_currentaddress;
        }

        private void WireUpFinancialForm()
        {
            //Aadhar and Pan
            AadharNumberTextBox.Text = model.documentModel.document_aadhar;
            PanNumberTextBox.Text = model.documentModel.document_pan;

            //Cibil Score
            CibilScoreTextBox.Text = model.documentModel.document_cibil.ToString();

            //Optional ID
            foreach (DocumentTypeModel document in documentModels)
            {
                if (document.documenttype_id == model.documentModel.document_id)
                {
                    OptionalIdTypeComboBox.SelectedItem = document;
                }
            }

            OptionalIdDetailsTextBox.Text = model.documentModel.document_optional;

            //In hand Income
            InHandMonthlyIcomeTextBox.Text = model.accountModel.account_inhandsalary.ToString();

            //Bank Name
            BankNameTextBox.Text = model.accountModel.account_bankname;

            //IFSC
            IFSCTextBox.Text = model.accountModel.account_ifsc;

            //Accounnt Number
            AccountNumberTextBox.Text = model.accountModel.account_number;

            //Loans
            foreach (LoanModel loan in model.loanModel)
            {
                createLoan(loan);
            }

        }

        private void SaveApplicantForm()
        {
            //First, Middle and Last Name

            model.applicantModel.applicant_firstname = FirstNameTextBox.Text;
            if (MiddleNameTextBox.Text.Length != 0)
            {
                model.applicantModel.applicant_middlename = MiddleNameTextBox.Text;
            }
            else
            {
                model.applicantModel.applicant_middlename = "";
            }
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
            string date = DatePicker.SelectedDate.ToString().Split(' ').First();
            string[] dateList = date.Split('-');

            string actualDate = $"{dateList[2]}-{dateList[1]}-{dateList[0]}";
            model.applicantModel.applicant_dob = actualDate;

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
            model.applicantModel.applicant_pincode = PincodeTextBox.Text;

            //Address
            model.applicantModel.applicant_currentaddress = AddressTextBlock.Text;

            //Mobile Number
            model.applicantModel.applicant_mobile = MobileNumberTextBox.Text;

            //Office Number
            model.applicantModel.applicant_officeno = OfficeNumberTextBox.Text;

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

        private void SaveGurantorForm()
        {
            //Co Applicant or Gurantor
            GurantorTypeModel gurantorTypeModel = (GurantorTypeModel)GurantorComboBox.SelectedItem;
            model.gurantorModel.gurantortype_id = gurantorTypeModel.gurantortype_id;

            //First, Middle and Last Name
            model.gurantorModel.gurantor_firstname = FirstNameApplicantTextBox.Text;
            if (MiddleNameApplicantTextBox.Text.Length != 0)
            {
                model.gurantorModel.gurantor_middlename = MiddleNameApplicantTextBox.Text;
            }
            else
            {
                model.gurantorModel.gurantor_middlename = "";
            }
            model.gurantorModel.gurantor_lastname = LastNameApplicantTextBox.Text;

            //Mobile
            model.gurantorModel.gurantor_mobile = MobilNumberApplicantTextBox.Text;

            //Relationship
            model.gurantorModel.gurantor_relation = RelationshipApplicantTextBox.Text;

            //Office Address
            model.gurantorModel.gurantor_currentaddress = OfficeAddressApplicantTextBlock.Text;
        }

        private void SaveLoanDetails()
        {
            foreach (NewLoanModel loan in existingLoans)
            {
                loan.LoanBankNameLabel = (TextBox)this.Dynamic.FindName(loan.LoanBankNameLabel.Name);
                loan.LoanAmountLabel = (TextBox)this.Dynamic.FindName(loan.LoanAmountLabel.Name);
                loan.LoanEmiAmountLabel = (TextBox)this.Dynamic.FindName(loan.LoanEmiAmountLabel.Name);
                loan.LoanTypeLabel = (ComboBox)this.Dynamic.FindName(loan.LoanTypeLabel.Name);
                if (ValidateNewLoanForms(loan))
                {
                    LoanModel loanModel = new LoanModel();
                    LoanTypeModel temp = (LoanTypeModel)loan.LoanTypeLabel.SelectedItem;
                    loan.LoanType = temp.loantype_id;
                    loan.LoanBankName = loan.LoanBankNameLabel.Text;
                    loan.LoanAmount = double.Parse(loan.LoanAmountLabel.Text);
                    loan.LoanEmiAmount = double.Parse(loan.LoanEmiAmountLabel.Text);
                    loanModel.loan_type = loan.LoanType;
                    loanModel.loan_bankname = loan.LoanBankName;
                    loanModel.loan_amount = loan.LoanAmount;
                    loanModel.loan_emi = loan.LoanEmiAmount;
                    loanModel.account_realtedaadhar = model.documentModel.document_aadhar;
                    loanModel.account_realtedpan = model.documentModel.document_pan;
                    loanModels.Add(loanModel);
                }
            }
        }

        private void SaveFinancialForm()
        {
            SaveLoanDetails();
            //Aadhar and Pan
            model.documentModel.document_aadhar = AadharNumberTextBox.Text;
            model.documentModel.document_pan = PanNumberTextBox.Text;

            model.applicantModel.applicant_aadhar = AadharNumberTextBox.Text;
            model.applicantModel.applicant_pan = PanNumberTextBox.Text;

            model.gurantorModel.gurantor_realtedaadhar = AadharNumberTextBox.Text;
            model.gurantorModel.gurantor_realtedpan = PanNumberTextBox.Text;

            model.accountModel.account_realtedaadhar = AadharNumberTextBox.Text;
            model.accountModel.account_realtedpan = PanNumberTextBox.Text;

            //Cibil Score
            model.documentModel.document_cibil = int.Parse(CibilScoreTextBox.Text);

            //Optional ID
            DocumentTypeModel documentType = (DocumentTypeModel)OptionalIdTypeComboBox.SelectedItem;
            model.documentModel.document_id = documentType.documenttype_id;
            model.documentModel.document_optional = OptionalIdDetailsTextBox.Text;

            //In hand Income
            model.accountModel.account_inhandsalary = int.Parse(InHandMonthlyIcomeTextBox.Text);

            //Bank Name
            model.accountModel.account_bankname = BankNameTextBox.Text;

            //IFSC 
            model.accountModel.account_ifsc = IFSCTextBox.Text;

            //Accounnt Number
            model.accountModel.account_number = AccountNumberTextBox.Text;

            //Loans
            model.loanModel = loanModels;
        }

        private void AddLoanButton_Click(object sender, RoutedEventArgs e)
        {
            Expander expander = addExpanderPannel(i);
            this.Dynamic.Children.Add(expander);
            this.Dynamic.RegisterName(expander.Name, expander);
            // Add Loan Model
            NewLoanModel loan = new NewLoanModel();
            /*
             * Loan Number - int
             * Loan Expander ID Name - string
             * Loan Type {ComboBox} - string
             * Bank name - string
             * Loan Amount - double
             * Loan Emi Amount - double
            */
            loan.LoanNumber = i + 1;
            loan.LoanExpanderName = $"LoanExpander{i}";
            loan.LoanTypeLabel.Name = $"LoanNameTextbox{i}";
            loan.LoanBankNameLabel.Name = $"LoanBankNameTextbox{i}";
            loan.LoanAmountLabel.Name = $"LoanLoanAmountTextbox{i}";
            loan.LoanEmiAmountLabel.Name = $"LoanEmiAmountTextbox{i}";
            existingLoans.Add(loan);
            i++;
        }

        private bool ValidateNewLoanForms(NewLoanModel model)
        {
            bool output = true;

            if (model.LoanTypeLabel.SelectedItem == null)
            {
                output = false;
            }
            if (model.LoanBankNameLabel.Text.Length == 0)
            {
                output = false;
            }
            if (model.LoanAmountLabel.Text.Length == 0)
            {
                output = false;
            }
            if (model.LoanEmiAmountLabel.Text.Length == 0)
            {
                output = false;
            }
            return output;
        }

        Expander addExpanderPannel(int i)
        {
            Expander LoanExpander = new Expander();
            LoanExpander.Name = "LoanExpander" + i.ToString();
            WrapPanel s = addLoanDetails(i);
            LoanExpander.Header = "Loan Number :" + (i + 1).ToString(); ;
            LoanExpander.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanExpander.FontSize = 20;
            LoanExpander.Content = s;
            LoanExpander.FontWeight = FontWeights.Light;

            return LoanExpander;
        }

        WrapPanel addLoanDetails(int i)
        {
            WrapPanel LoanDetails = new WrapPanel();
            LoanDetails.Orientation = Orientation.Vertical;
            LoanDetails.Background = new SolidColorBrush(Colors.WhiteSmoke);


            LoanDetails.Name = "LoanBankNameTextbox" + i.ToString();

            Label LoanTypeLabel = new Label();
            ComboBox LoanType = addLoanType(i);
            Label LoanBankNameLabel = new Label();
            TextBox LoanBankName = addLoanBankName(i);
            Label LoanAmountLabel = new Label();
            TextBox LoanAmount = addLoanAmount(i);
            Label LoanEmiAmountLabel = new Label();
            TextBox LoanEmiAmount = addLoanEmiAmount(i);


            LoanTypeLabel.Content = "Loan Name";
            LoanBankNameLabel.Content = "Bank Name";
            LoanAmountLabel.Content = "Loan Amount";
            LoanEmiAmountLabel.Content = "Loan EMI";



            LoanTypeLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanBankNameLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanAmountLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanEmiAmountLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);


            LoanTypeLabel.FontSize = 20;
            LoanBankNameLabel.FontSize = 20;
            LoanAmountLabel.FontSize = 20;
            LoanEmiAmountLabel.FontSize = 20;

            LoanTypeLabel.FontWeight = FontWeights.Light;
            LoanBankNameLabel.FontWeight = FontWeights.Light;
            LoanAmountLabel.FontWeight = FontWeights.Light;
            LoanEmiAmountLabel.FontWeight = FontWeights.Light;

            LoanType.Margin = new Thickness(5);
            LoanBankName.Margin = new Thickness(5);
            LoanAmount.Margin = new Thickness(5);
            LoanEmiAmount.Margin = new Thickness(5);
            LoanTypeLabel.Margin = new Thickness(5);
            LoanBankNameLabel.Margin = new Thickness(5);
            LoanAmountLabel.Margin = new Thickness(5);
            LoanEmiAmountLabel.Margin = new Thickness(5);



            LoanDetails.Children.Add(LoanTypeLabel);
            LoanDetails.Children.Add(LoanType);
            this.Dynamic.RegisterName(LoanType.Name, LoanType);
            LoanDetails.Children.Add(LoanBankNameLabel);
            LoanDetails.Children.Add(LoanBankName);
            this.Dynamic.RegisterName(LoanBankName.Name, LoanBankName);
            LoanDetails.Children.Add(LoanAmountLabel);
            LoanDetails.Children.Add(LoanAmount);
            this.Dynamic.RegisterName(LoanAmount.Name, LoanAmount);
            LoanDetails.Children.Add(LoanEmiAmountLabel);
            LoanDetails.Children.Add(LoanEmiAmount);
            this.Dynamic.RegisterName(LoanEmiAmount.Name, LoanEmiAmount);


            return LoanDetails;

        }

        ComboBox addLoanType(int i)
        {
            ComboBox LoanType = new ComboBox();
            LoanType.Name = $"LoanNameTextbox{i}";                                //"LoanNameTextbox" + i.ToString();
            LoanType.Width = 200;
            LoanType.Height = 30;
            LoanType.ItemsSource = loanTypes;
            LoanType.DisplayMemberPath = "loantype_name";
            return LoanType;
        }

        TextBox addLoanBankName(int i)
        {
            TextBox LoanBankName = new TextBox();
            LoanBankName.Name = $"LoanBankNameTextbox{i}";                        //"LoanBankNameTextbox" + i.ToString();
            LoanBankName.Margin = new Thickness(10);
            LoanBankName.Width = 200;
            LoanBankName.Height = 30;
            return LoanBankName;
        }

        TextBox addLoanAmount(int i)
        {
            TextBox LoanAmount = new TextBox();
            LoanAmount.Name = $"LoanLoanAmountTextbox{i}";                        //"LoanLoanAmountTextbox" + i.ToString();
            LoanAmount.Margin = new Thickness(10);
            LoanAmount.Width = 200;
            LoanAmount.Height = 30;
            return LoanAmount;
        }

        TextBox addLoanEmiAmount(int i)
        {
            TextBox LoanEmiAmount = new TextBox();
            LoanEmiAmount.Name = $"LoanEmiAmountTextbox{i}";                       //"LoanEmiAmountTextbox" + i.ToString();
            LoanEmiAmount.Margin = new Thickness(10);
            LoanEmiAmount.Width = 200;
            LoanEmiAmount.Height = 30;
            return LoanEmiAmount;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            SaveApplicantForm();
            SaveGurantorForm();
            SaveFinancialForm();
            string output = JsonConvert.SerializeObject(model);
            try
            {
                GlobalConfig.Connection.CreateCar(model);
                MessageBox.Show("New KYC Created!");
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            
            WriteJson(output);
            callingForm.SearchScreen();
        }

        private void WriteJson(string json)
        {
            try
            {
                if (!Directory.Exists($"{GlobalConfig.FilePath}\\JsonBackup"))
                {
                    System.IO.Directory.CreateDirectory($"{GlobalConfig.FilePath}\\JsonBackup");
                }
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter($"{GlobalConfig.FilePath}\\JsonBackup\\jsonBackup_{model.applicantModel.applicant_aadhar}.txt");
                //Write a line of text
                sw.WriteLine(json);
                //Close the file
                sw.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Exception: " + a.Message);
            }
        }

        public void DisableButton()
        {
            SubmitButton.IsEnabled = false;
        }

        public void EnableButton()
        {
            SubmitButton.IsEnabled = true;
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

        private void OptionalIdTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DocumentTypeModel selectedModel = (DocumentTypeModel)OptionalIdTypeComboBox.SelectedItem;

            if (selectedModel.documenttype_name == "None")
            {
                OptionalIdDetailsTextBox.Clear();
                OptionalIdDetailsTextBox.IsEnabled = false;
                SubmitButton.IsEnabled = true;
            }
            else
            {
                OptionalIdDetailsTextBox.IsEnabled = true;
            }
        }
    }
}
