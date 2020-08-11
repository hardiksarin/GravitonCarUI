﻿using GravitonCar.Models;
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
    /// Interaction logic for Preview.xaml
    /// </summary>
    public partial class Preview : UserControl
    {
        CarModel model = new CarModel();
        private List<MarriedStatusModel> maritalStatusList = new List<MarriedStatusModel>();
        private List<AcquaintanceModel> acquaintanceList = new List<AcquaintanceModel>();
        private List<CasteModel> casteList = new List<CasteModel>();
        private List<CategoryModel> categoryList = new List<CategoryModel>();
        private List<string> stateList = new List<string>() { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttarakhand", "Uttar Pradesh", "West Bengal", "Andaman and Nicobar Islands", "Chandigarh", "Dadra and Nagar Haveli", "Daman and Diu", "Delhi", "Lakshadweep", "Puducherry" };
        private List<string> educationList = new List<string>() { "Postgraduate ", "Undergraduate", "Higher secondary", "Matriculation" };
        private List<string> branchesList = new List<string>() { "Jaipur Office " };
        private List<GurantorTypeModel> gurantorType = new List<GurantorTypeModel>();
        private List<LoanTypeModel> loanTypes = new List<LoanTypeModel>();
        private List<DocumentTypeModel> documentModels = new List<DocumentTypeModel>();
        List<LoanModel> loanModels = new List<LoanModel>();
        int i = 0;
        List<NewLoanModel> existingLoans = new List<NewLoanModel>();

        public Preview(IScreenRequester caller, CarModel carModel)
        {
            InitializeComponent();
            model = carModel;
            LoadListData();
            WireUpLists();
            WireUpPreviewForm();
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
            LoanType.Height = 30;
            LoanType.ItemsSource = loanTypes;
            LoanType.DisplayMemberPath = "loantype_name";
            LoanType.SelectedIndex = loan.loan_type;
            return LoanType;
        }

        TextBox addLoanBankNameDynamic(int i, LoanModel loan)
        {
            TextBox LoanBankName = new TextBox();
            LoanBankName.Name = $"LoanBankNameTextbox{i}";                        //"LoanBankNameTextbox" + i.ToString();
            LoanBankName.Margin = new Thickness(10);
            LoanBankName.Width = 200;
            LoanBankName.Height = 30;
            LoanBankName.Text = loan.loan_bankname;
            return LoanBankName;
        }

        TextBox addLoanAmountDynamic(int i, LoanModel loan)
        {
            TextBox LoanAmount = new TextBox();
            LoanAmount.Name = $"LoanLoanAmountTextbox{i}";                        //"LoanLoanAmountTextbox" + i.ToString();
            LoanAmount.Margin = new Thickness(10);
            LoanAmount.Width = 200;
            LoanAmount.Height = 30;
            LoanAmount.Text = loan.loan_amount.ToString();
            return LoanAmount;
        }

        TextBox addLoanEmiAmountDynamic(int i, LoanModel loan)
        {
            TextBox LoanEmiAmount = new TextBox();
            LoanEmiAmount.Name = $"LoanEmiAmountTextbox{i}";                       //"LoanEmiAmountTextbox" + i.ToString();
            LoanEmiAmount.Margin = new Thickness(10);
            LoanEmiAmount.Width = 200;
            LoanEmiAmount.Height = 30;
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
            MiddleNameTextBox.Text = model.applicantModel.applicant_middlename;
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
            Distance To NE - DistanceToNeTextBox
            Nearest Branch - NearestBranchComboBox
            */

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
            MiddleNameApplicantTextBox.Text = model.gurantorModel.gurantor_middlename;
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
            model.gurantorModel.gurantor_middlename = MiddleNameApplicantTextBox.Text;
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
                    loanModel.loan_relatedaadhar = model.documentModel.document_aadhar;
                    loanModel.loan_relatedpan = model.documentModel.document_pan;
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

            model.accountModel.account_relatedaadhar = AadharNumberTextBox.Text;
            model.accountModel.account_relatedpan = PanNumberTextBox.Text;

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
        }
    }
}
