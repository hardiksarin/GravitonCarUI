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
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorLastname
        {
            get { return _gurantor_lastname; }
            set { _gurantor_lastname = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorCurrentAddress
        {
            get { return _gurantor_currentaddress; }
            set { _gurantor_currentaddress = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorMobile
        {
            get { return _gurantor_mobile; }
            set { _gurantor_mobile = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }

        public string GurantorRelation
        {
            get { return _gurantor_relation; }
            set { _gurantor_relation = value;
                OnPropertyChanged("GurantorFirstname");
            }
        }



        IScreenRequester callingForm;
        CarModel model = new CarModel();
        List<GurantorTypeModel> gurantorType = new List<GurantorTypeModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public CoApplicantForm(IScreenRequester caller, CarModel carModel)
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

        private void WireUpList()
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
            WireUpForm();
            callingForm.RemoveCoApplicantScreen(this);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            WireUpForm();
            callingForm.FinancialScreen(model);
        }

        private void WireUpData()
        {
            if (model.gurantorModel.gurantor_firstname != null)
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
                FirstNameTextBox.Text = model.gurantorModel.gurantor_firstname;
                MiddleNameTextBox.Text = model.gurantorModel.gurantor_middlename;
                LastNameTextBox.Text = model.gurantorModel.gurantor_lastname;

                //Mobile
                MobilNumberTextBox.Text = model.gurantorModel.gurantor_mobile;

                //Relationship
                RelationshipTextBox.Text = model.gurantorModel.gurantor_relation;

                //Office Address
                OfficeAddressTextBlock.Text = model.gurantorModel.gurantor_currentaddress; 
            }
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
            model.gurantorModel.gurantor_mobile = MobilNumberTextBox.Text;

            //Relationship
            model.gurantorModel.gurantor_relation = RelationshipTextBox.Text;

            //Office Address
            model.gurantorModel.gurantor_currentaddress = OfficeAddressTextBlock.Text;
        }

        public void DisableButton()
        {
            NextButton.IsEnabled = false;
        }

        public void EnableButton()
        {
            NextButton.IsEnabled = true;
        }
    }
}
