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
                applicantList = GlobalConfig.Connection.GetApplicant_All();

            }
            catch(Exception e)
            {
                if (MessageBox.Show($" Exception : {e.Message} ", "Graviton - Connection Error", MessageBoxButton.OK) == MessageBoxResult.OK)
                    Environment.Exit(0);
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
    }
}
