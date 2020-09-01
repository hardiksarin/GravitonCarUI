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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        List<string> searchList = new List<string>();
        List<ApplicantModel> applicantList = new List<ApplicantModel>();
        public static List<MarriedStatusModel> maritalStatusList = new List<MarriedStatusModel>();
        public static List<AcquaintanceModel> acquaintanceList = new List<AcquaintanceModel>();
        public static List<CasteModel> casteList = new List<CasteModel>();
        public static List<CategoryModel> categoryList = new List<CategoryModel>();
        public static List<string> stateList = new List<string>() { "Andaman and Nicobar Islands", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra and Nagar Haveli", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Puducherry", "Punjab", "Rajasthan", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" };
        public static List<string> educationList = new List<string>() { "Postgraduate ", "Undergraduate", "Higher secondary", "Matriculation" };
        public static List<string> branchesList = new List<string>() { "Jaipur Office " };
        public static List<GurantorTypeModel> gurantorType = new List<GurantorTypeModel>();
        public static List<LoanTypeModel> loanTypes = new List<LoanTypeModel>();
        public static List<DocumentTypeModel> documentModels = new List<DocumentTypeModel>();
        IScreenRequester callingForm;
        public Search(IScreenRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            LoadListData();
            //WireUpList();
            //GetSearchList();
            CarNumber.Text = applicantList.Count.ToString();
        }

        private void LoadListData()
            
        {
            try {
                if (applicantList.Count == 0)
                {
                    applicantList = GlobalConfig.Connection.GetApplicant_All(); 
                }

            }
            catch(Exception e)
            {
                if (MessageBox.Show($" Exception : {e.Message} ", "Graviton - Connection Error", MessageBoxButton.OK) == MessageBoxResult.OK)
                    Environment.Exit(0);
            }

            try
            {
                if (maritalStatusList.Count == 0)
                {
                    maritalStatusList = GlobalConfig.Connection.GetMarried_All(); 
                }
                if (acquaintanceList.Count == 0)
                {
                    acquaintanceList = GlobalConfig.Connection.GetAcquaintance_All(); 
                }
                if (casteList.Count == 0)
                {
                    casteList = GlobalConfig.Connection.GetCaste_All(); 
                }
                if (categoryList.Count == 0)
                {
                    categoryList = GlobalConfig.Connection.GetCategory_All(); 
                }

                if (gurantorType.Count == 0)
                {
                    gurantorType = GlobalConfig.Connection.GetGurantorType_All(); 
                }

                if (loanTypes.Count == 0)
                {
                    loanTypes = GlobalConfig.Connection.GetLoanType_All(); 
                }
                if (documentModels.Count == 0)
                {
                    documentModels = GlobalConfig.Connection.GetDocumentType_All(); 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception : " + e);
            }

        }

        private void WireUpList()
        {
            ListBoxItems.ItemsSource = null;
            ListBoxItems.ItemsSource = applicantList;

            ListBoxItems.DisplayMemberPath = "DisplaySearch";
        }

        /*private void GetSearchList()
        {
            foreach (ApplicantModel applicant in applicantList)
            {
                string temp = $"{applicant.applicant_firstname} - {applicant.applicant_aadhar}";
                searchList.Add(temp);
            }
        }*/

        private void CommentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(CommentTextBox.Text) == false)
            {
                //ListBoxItems.Items.Clear();
                ListBoxItems.ItemsSource = null;
                ListBoxItems.Items.Clear();
                foreach (ApplicantModel str in applicantList)
                {
                    if (str.DisplaySearch.Contains(CommentTextBox.Text))
                    {
                        ListBoxItems.Items.Add(str);
                    }

                }
            }
            else if (CommentTextBox.Text == "")
            {
                ListBoxItems.Items.Clear();
                /*foreach (ApplicantModel str in applicantList)
                {
                    WireUpList();
                    //ListBoxItems.Items.Add(str);
                }*/
            }
        }

        private CarModel GetCar(string pan, string aadhar)
        {
            CarModel car = new CarModel();
            car = GlobalConfig.Connection.GetCar_ById(aadhar, pan);
            return car;
        }

        private void ListBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicantModel applicant = (ApplicantModel)ListBoxItems.SelectedItem;
            CarModel model = GetCar(applicant.applicant_pan, applicant.applicant_aadhar);
            callingForm.DisplayScreen(model);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            callingForm.ApplicantForm();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            callingForm.SearchScreen();
            //LoadListData();
        }
    }
}
