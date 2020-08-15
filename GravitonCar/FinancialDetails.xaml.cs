using GravitonCar.Models;
using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for FinancialDetails.xaml
    /// </summary>
    public partial class FinancialDetails : UserControl, INotifyPropertyChanged, IValidateError
    {

        private string _document_aadhar;
        private string _document_pan;
        private int _document_cibil;
        private string _document_optional;
        private string _account_bankname;
        private string _account_ifsc;
        private string _account_number;
        private int _account_inhandsalary;

        public string DocumentAadhar
        {
            get { return _document_aadhar; }
            set { _document_aadhar = value;
                OnPropertyChanged("DocumentAadhar");
            }
        }


        public string DocumentPan
        {
            get { return _document_pan; }
            set { _document_pan = value;
                OnPropertyChanged("DocumentPan");
            }
        }


        public int DocumentCibil
        {
            get { return _document_cibil; }
            set { _document_cibil = value;
                OnPropertyChanged("DocumentCibil");
            }
        }


        public string DocumentOptional
        {
            get { return _document_optional; }
            set { _document_optional = value;
                OnPropertyChanged("DocumentOptional");
            }
        }


        public string AccountBankName
        {
            get { return _account_bankname; }
            set { _account_bankname = value;
                OnPropertyChanged("AccountBankName");
            }
        }


        public string AccountIfsc
        {
            get { return _account_ifsc; }
            set { _account_ifsc = value;
                OnPropertyChanged("AccountIfsc");
            }
        }


        public string AccountNumber
        {
            get { return _account_number; }
            set { _account_number = value;
                OnPropertyChanged("AccountNumber");
            }
        }


        public int AccountSalary
        {
            get { return _account_inhandsalary; }
            set { _account_inhandsalary = value;
                OnPropertyChanged("AccountSalary");
            }
        }












        int i = 0;
        List<NewLoanModel> existingLoans = new List<NewLoanModel>();
        List<LoanTypeModel> loanTypes = new List<LoanTypeModel>();
        List<LoanModel> loanModels = new List<LoanModel>();
        List<DocumentTypeModel> documentModels = new List<DocumentTypeModel>();
        IScreenRequester callingForm;
        CarModel model = new CarModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public FinancialDetails(IScreenRequester caller, CarModel carModel)
        {
            DataContext = this;
            InitializeComponent();
            ApplicantDetailsFormUserControl.errorForm = this;
            callingForm = caller;
            model = carModel;
            LoadListData();
            WireUpList();
            WireUpData();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadListData()
        {
            loanTypes = GlobalConfig.Connection.GetLoanType_All();
            documentModels = GlobalConfig.Connection.GetDocumentType_All();
        }

        private void WireUpList()
        {
            OptionalIdTypeComboBox.ItemsSource = null;
            OptionalIdTypeComboBox.ItemsSource = documentModels;

            OptionalIdTypeComboBox.DisplayMemberPath = "documenttype_name";
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

        /// <summary>
        /// Validates Each new loan.
        /// New Loan Model will provide the XAML ids of each component to this function.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
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
            WireUpForm();
            callingForm.PreviewScreen(model);
        }

        private void WireUpData()
        {
            //Aadhar and Pan
            if (model.documentModel.document_aadhar != null)
            {
                AadharNumberTextBox.Text = model.documentModel.document_aadhar; 
            }
            if (model.documentModel.document_pan != null)
            {
                PanNumberTextBox.Text = model.documentModel.document_pan; 
            }

            //Cibil Score
            if (model.documentModel.document_cibil != 0)
            {
                CibilScoreTextBox.Text = model.documentModel.document_cibil.ToString(); 
            }

            //Optional ID
            if (model.documentModel.document_id != 0)
            {
                foreach (DocumentTypeModel document in documentModels)
                {
                    if (document.documenttype_id == model.documentModel.document_id)
                    {
                        OptionalIdTypeComboBox.SelectedItem = document;
                    }
                } 
            }

            if (model.documentModel.document_optional != null)
            {
                OptionalIdDetailsTextBox.Text = model.documentModel.document_optional; 
            }

            //In hand Income
            if (model.accountModel.account_inhandsalary != 0)
            {
                InHandMonthlyIcomeTextBox.Text = model.accountModel.account_inhandsalary.ToString(); 
            }

            //Bank Name
            if (model.accountModel.account_bankname != null)
            {
                BankNameTextBox.Text = model.accountModel.account_bankname; 
            }

            //IFSC
            if (model.accountModel.account_ifsc != null)
            {
                IFSCTextBox.Text = model.accountModel.account_ifsc;
            }
            //Accounnt Number
            if (model.accountModel.account_number != null)
            {
                AccountNumberTextBox.Text = model.accountModel.account_number; 
            }

            //Loans
            if (model.loanModel.Count != 0)
            {
                foreach (LoanModel loan in model.loanModel)
                {
                    createLoan(loan);
                } 
            }
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

        private void WireUpForm()
        {
            //Aadhar and Pan
            if (AadharNumberTextBox.Text.Length != 0)
            {
                model.documentModel.document_aadhar = AadharNumberTextBox.Text;
                model.applicantModel.applicant_aadhar = AadharNumberTextBox.Text;
                model.gurantorModel.gurantor_realtedaadhar = AadharNumberTextBox.Text;
                model.accountModel.account_relatedaadhar = AadharNumberTextBox.Text;
            }

            if (PanNumberTextBox.Text.Length != 0)
            {
                model.documentModel.document_pan = PanNumberTextBox.Text;
                model.applicantModel.applicant_pan = PanNumberTextBox.Text;
                model.gurantorModel.gurantor_realtedpan = PanNumberTextBox.Text;
                model.accountModel.account_relatedpan = PanNumberTextBox.Text; 
            }

            //Cibil Score
            if (CibilScoreTextBox.Text.Length != 0)
            {
                model.documentModel.document_cibil = int.Parse(CibilScoreTextBox.Text); 
            }

            //Optional ID
            if (OptionalIdTypeComboBox.SelectedItem != null)
            {
                DocumentTypeModel documentType = (DocumentTypeModel)OptionalIdTypeComboBox.SelectedItem;
                model.documentModel.document_id = documentType.documenttype_id; 
            }
            if (OptionalIdDetailsTextBox.Text.Length != 0)
            {
                model.documentModel.document_optional = OptionalIdDetailsTextBox.Text; 
            }

            //In hand Income
            if (InHandMonthlyIcomeTextBox.Text.Length != 0)
            {
                model.accountModel.account_inhandsalary = int.Parse(InHandMonthlyIcomeTextBox.Text); 
            }

            //Bank Name
            if (BankNameTextBox.Text.Length != 0)
            {
                model.accountModel.account_bankname = BankNameTextBox.Text; 
            }

            //IFSC 
            if (IFSCTextBox.Text.Length != 0)
            {
                model.accountModel.account_ifsc = IFSCTextBox.Text; 
            }

            //Accounnt Number
            if (AccountNumberTextBox.Text.Length != 0)
            {
                model.accountModel.account_number = AccountNumberTextBox.Text; 
            }

            //Loans
            if (loanModels.Count != 0)
            {
                model.loanModel = loanModels; 
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
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
            WireUpForm();
            callingForm.RemoveFinancialScreen(this);
        }

        public void DisableButton()
        {
            ReviewButton.IsEnabled = false;
        }

        public void EnableButton()
        {
            ReviewButton.IsEnabled = true;
        }
    }
}
