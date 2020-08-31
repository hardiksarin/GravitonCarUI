using GravitonCar.Models;
using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using Newtonsoft.Json;
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
    /// Interaction logic for NewUserForm.xaml
    /// </summary>
    public partial class NewUserForm : UserControl
    {
        IScreenRequester callingForm;
        List<string> userAccess = new List<string>() {"Admin", "Employee" };
        public NewUserForm(IScreenRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            WireUpList();
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

                    user.is_active = true;

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
