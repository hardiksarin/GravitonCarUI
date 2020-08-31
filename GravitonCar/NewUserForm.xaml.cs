using GravitonCar.Models;
using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using Newtonsoft.Json;
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
    /// Interaction logic for NewUserForm.xaml
    /// </summary>
    public partial class NewUserForm : UserControl, INotifyPropertyChanged
    {

        private string _fyllName;
        private string _username;
        private string _designation;
        private string _userMobile;
        private string _password;
        private string _confirmpassword;



        public string FullName
        {
            get { return _fyllName; }
            set { _fyllName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value;
                OnPropertyChanged("Username");
            }
        }
 

        public string Designation
        {
            get { return _designation; }
            set { _designation = value;
                OnPropertyChanged("Designation");
            }
        }

        public string UserMobile
        {
            get { return _userMobile; }
            set { _userMobile = value;
                OnPropertyChanged("UserMobile");
            }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string ConfirmPassword {
            get { return _confirmpassword; }
            set { _confirmpassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }










        IScreenRequester callingForm;
        List<string> userAccess = new List<string>() {"Admin", "Employee" };

        public event PropertyChangedEventHandler PropertyChanged;

        public NewUserForm(IScreenRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            WireUpList();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void WireUpList()
        {
            UserAccessCombobox.ItemsSource = null;
            UserAccessCombobox.ItemsSource = userAccess;
        }

        private bool ValidateForm()
        {
            bool output = true;

            if(FullNameTextBox.Text.Length == 0)
            {
                output = false;
            }
            if(UsernameTextBox.Text.Length == 0)
            {
                output = false;
            }
            if(DesignationTextBox.Text.Length == 0)
            {
                output = false;
            }
            if(PhoneNumberTextbox.Text.Length == 0)
            {
                output = false;
            }
            if(PasswordTextbox.Text.Length == 0)
            {
                output = false;
            }
            if(ConfirmPasswordBox.Password.Length == 0)
            {
                output = false;
            }
            if(UserAccessCombobox.SelectedItem == null)
            {
                output = false;
            }

            return output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                if (PasswordTextbox.Text.Equals(ConfirmPasswordBox.Password))
                {

                    //Create USer
                    UserModel user = new UserModel();

                    user.full_name = FullNameTextBox.Text;
                    user.username = UsernameTextBox.Text;
                    user.designation = DesignationTextBox.Text;
                    user.user_mobile = PhoneNumberTextbox.Text;
                    user.password = PasswordTextbox.Text;

                    //Permissions
                    string access = (string)UserAccessCombobox.SelectedItem;

                    UserAccess u = new UserAccess();

                    if (access == "Admin")
                    {
                        u.Admin = true;
                        u.Employee = false;
                        user.permissions = JsonConvert.SerializeObject(u);
                    }
                    else if(access == "Employee")
                    {
                        u.Admin = false;
                        u.Employee = true;
                        user.permissions = JsonConvert.SerializeObject(u);
                    }

                    try
                    {
                        GlobalConfig.Connection.CreateUser(user);
                        callingForm.AdminPanel();
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                    }
                }
                else
                {
                    //Password mismatch
                    MessageBox.Show("Password mismatch!");
                }
            }
            else
            {
                //Empty field
                MessageBox.Show("Please fill all the fields!");
            }
        }
    }
}
