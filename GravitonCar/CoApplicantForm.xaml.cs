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
    /// Interaction logic for CoApplicantForm.xaml
    /// </summary>
    public partial class CoApplicantForm : UserControl
    {
        IScreenRequester callingForm;
        CarModel model = new CarModel();
        List<GurantorTypeModel> gurantorType = new List<GurantorTypeModel>();
        public CoApplicantForm(IScreenRequester caller, CarModel carModel)
        {
            InitializeComponent();
            callingForm = caller;
            model = carModel;
            LoadListData();
            WireUpData();
        }

        private void WireUpData()
        {
            GurantorComboBox.ItemsSource = null;
            GurantorComboBox.ItemsSource = gurantorType;
            GurantorComboBox.DisplayMemberPath = "gurantortype_name";
        }

        private void LoadListData()
        {
            gurantorType = GlobalConfig.Connection.GetGurantorType_All();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            callingForm.RemoveCoApplicantScreen(this);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            WireUpForm();
            callingForm.FinancialScreen(model);
        }

        private void WireUpForm()
        {
            //Co Applicant or Gurantor
            GurantorTypeModel gurantorTypeModel = (GurantorTypeModel)GurantorComboBox.SelectedItem;
            model.gurantorModel.gurantortype_id = gurantorTypeModel.gurantortype_id;

            //First, Middle and Last Name
            model.gurantorModel.gurantor_firstname = FirstNameTextBox.Text;
            model.gurantorModel.gurantor_middlename = MiddleNameTextBox.Text;
            model.gurantorModel.gurantor_lastname = LastNameTextBox.Text;

            //Mobile
            model.gurantorModel.gurantor_mobile = long.Parse(MobilNumberTextBox.Text);

            //Relationship
            model.gurantorModel.gurantor_relation = RelationshipTextBox.Text;

            //Office Address
            model.gurantorModel.gurantor_currentaddress = OfficeAddressTextBlock.Text;
        }
    }
}
