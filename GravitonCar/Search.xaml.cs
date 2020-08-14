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
        public Search()
        {
            InitializeComponent();
            LoadListData();
            GetSearchList();
        }

        private void LoadListData()
        {
            applicantList = GlobalConfig.Connection.GetApplicant_All();
        }

        private void WireUpList()
        {
            ListBoxItems.ItemsSource = null;
            ListBoxItems.ItemsSource = searchList;
        }

        private void GetSearchList()
        {
            foreach (ApplicantModel applicant in applicantList)
            {
                string temp = $"{applicant.applicant_firstname} - {applicant.applicant_aadhar}";
                searchList.Add(temp);
            }
        }

        private void CommentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(CommentTextBox.Text) == false)
            {
                //ListBoxItems.Items.Clear();
                ListBoxItems.ItemsSource = null;
                ListBoxItems.Items.Clear();
                foreach (string str in searchList)
                {
                    if (str.Contains(CommentTextBox.Text))
                    {
                        ListBoxItems.Items.Add(str);
                    }

                }
            }
            else if (CommentTextBox.Text == "")
            {
                ListBoxItems.Items.Clear();
                foreach (string str in searchList)
                {
                    WireUpList();
                    //ListBoxItems.Items.Add(str);
                }
            }
        }
    }
}
