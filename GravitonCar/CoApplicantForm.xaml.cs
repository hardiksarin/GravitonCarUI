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
    /// Interaction logic for CoApplicantForm.xaml
    /// </summary>
    public partial class CoApplicantForm : UserControl, INotifyPropertyChanged, IValidateError
    {
        private string _gurantor_firstname;
        private string _gurantor_middlename;
        private string _gurantor_lastname;
        private string _gurantor_currentaddress;
        private string _gurantor_mobile;
        private string _gurantor_relation;


        public string GurantorFirstname
        {
            get { return _gurantor_firstname; }
            set { _gurantor_firstname = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorMiddlename
        {
            get { return _gurantor_middlename; }
            set { _gurantor_middlename = value;
                OnPropertyChanged("GurantorMiddlename");
            }
        }

        public string GurantorLastname
        {
            get { return _gurantor_lastname; }
            set { _gurantor_lastname = value;
                OnPropertyChanged("GurantorLastname");
            }
        }

        public string GurantorCurrentAddress
        {
            get { return _gurantor_currentaddress; }
            set { _gurantor_currentaddress = value;
                OnPropertyChanged("GurantorCurrentAddress");
            }
        }

        public string GurantorMobile
        {
            get { return _gurantor_mobile; }
            set { _gurantor_mobile = value;
                OnPropertyChanged("GurantorMobile");
            }
        }

        public string GurantorRelation
        {
            get { return _gurantor_relation; }
            set { _gurantor_relation = value;
                OnPropertyChanged("GurantorRelation");
            }
        }

        public static bool AddressChecked;



        IScreenRequester callingForm;
        CarModel model = new CarModel();
        //List<GurantorTypeModel> gurantorType = new List<GurantorTypeModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public CoApplicantForm(IScreenRequester caller, CarModel carModel)
        {
            DataContext = this;
            InitializeComponent();
            ApplicantDetailsFormUserControl.errorForm = this;
            callingForm = caller;
            model = carModel;
            //LoadListData();
            WireUpList();
            WireUpData();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void WireUpList()
        {
            GurantorComboBox.ItemsSource = null;
            GurantorComboBox.ItemsSource = Search.gurantorType;
            GurantorComboBox.DisplayMemberPath = "gurantortype_name";
        }

        /*private void LoadListData()
        {
            gurantorType = GlobalConfig.Connection.GetGurantorType_All();
        }*/

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WireUpForm();
            callingForm.RemoveCoApplicantScreen(this);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCoapplicantForm())
            {
                WireUpForm();
                callingForm.FinancialScreen(model);
            }
            else
            {
                SnackbarSix.IsActive = true;
                SnackbarSix.MessageQueue.Enqueue("Please enter all fields", null,
                    null,
                    null,
                    false,
                    true,
                    TimeSpan.FromSeconds(5));

            }
        }

        private void WireUpData()
        {
            if (model.gurantorModel.gurantortype_id != 0)
            {
                foreach (GurantorTypeModel gurantor in Search.gurantorType)
                {
                    if (model.gurantorModel.gurantortype_id == gurantor.gurantortype_id)
                    {
                        GurantorComboBox.SelectedItem = gurantor;
                    }
                } 
            }

            //First, Middle and Last Name
            if (model.gurantorModel.gurantor_firstname != null)
            {
                GurantorFirstname = model.gurantorModel.gurantor_firstname;
            }
            if (model.gurantorModel.gurantor_middlename != null)
            {
                GurantorMiddlename = model.gurantorModel.gurantor_middlename; 
            }
            if (model.gurantorModel.gurantor_lastname != null)
            {
                GurantorLastname = model.gurantorModel.gurantor_lastname;
            }

            //Mobile
            if (model.gurantorModel.gurantor_mobile != null)
            {
                GurantorMobile = model.gurantorModel.gurantor_mobile; 
            }

            //Relationship
            if (model.gurantorModel.gurantor_relation != null)
            {
                GurantorRelation = model.gurantorModel.gurantor_relation; 
            }

            //Office Address Checkbox
            AddressCheckbox.IsChecked = AddressChecked;

            //Office Address
            if (model.gurantorModel.gurantor_currentaddress != null)
            {
                if(AddressChecked == true)
                {
                    GurantorCurrentAddress = model.applicantModel.applicant_currentaddress;
                }
                else
                {
                    GurantorCurrentAddress = model.gurantorModel.gurantor_currentaddress;
                }
            }
        }

        private void WireUpForm()
        {
            //Co Applicant or Gurantor
            if (GurantorComboBox.SelectedItem != null)
            {
                GurantorTypeModel gurantorTypeModel = (GurantorTypeModel)GurantorComboBox.SelectedItem;
                model.gurantorModel.gurantortype_id = gurantorTypeModel.gurantortype_id;
            }

            //First, Middle and Last Name
            if (GurantorFirstname != null)
            {
                model.gurantorModel.gurantor_firstname = GurantorFirstname;
            }
            if (GurantorMiddlename != null)
            {
                model.gurantorModel.gurantor_middlename = GurantorMiddlename;
            }
            else
            {
                model.gurantorModel.gurantor_middlename = "";
            }
            if (GurantorLastname != null)
            {
                model.gurantorModel.gurantor_lastname = GurantorLastname;
            }

            //Mobile
            if (GurantorMobile != null)
            {
                model.gurantorModel.gurantor_mobile = GurantorMobile;
            }

            //Relationship
            if (GurantorRelation != null)
            {
                model.gurantorModel.gurantor_relation = GurantorRelation;
            }

            //Office Address
            if (GurantorCurrentAddress != null)
            {
                model.gurantorModel.gurantor_currentaddress = GurantorCurrentAddress;
            }
        }

        private bool ValidateCoapplicantForm()
        {

            if(GurantorComboBox.SelectedItem == null)
            {
                return false;
            }
            if(GurantorFirstname == null)
            {
                return false;
            }          
            if(GurantorLastname == null)
            {
                return false;
            }
            if(GurantorMobile == null)
            {
                return false;
            }
            if(GurantorRelation == null)
            {
                return false;
            }
            if(OfficeAddressTextBlock.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        public void DisableButton()
        {
            NextButton.IsEnabled = false;
        }

        public void EnableButton()
        {
            NextButton.IsEnabled = true;
        }

        private void AddressCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            
            OfficeAddressTextBlock.Clear();

            if (model.applicantModel.applicant_currentaddress != null)
            {
                OfficeAddressTextBlock.Text = model.applicantModel.applicant_currentaddress; 
            }
            OfficeAddressTextBlock.IsReadOnly = true;

            AddressChecked = true;
            
            
        }

        private void AddressCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            OfficeAddressTextBlock.Clear();
            OfficeAddressTextBlock.IsReadOnly = false;

            AddressChecked = false;
        }
    }
}
