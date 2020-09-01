using GravitonCarLibrary.Models;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace GravitonCar
{
    /// <summary>
    /// Interaction logic for UserCredenitalsWindow.xaml
    /// </summary>
    public partial class UserCredenitalsWindow : Window
    {
        IUserCredentialRequester callingForm;
        PackIcon icon = new PackIcon();
        UserModel userModel = new UserModel();
        bool isChanged = false;
        public UserCredenitalsWindow(IUserCredentialRequester caller, UserModel user, PackIcon packIcon)
        {
            InitializeComponent();
            callingForm = caller;
            userModel = user;
            icon = packIcon;
            wireupData();
            this.Owner = MainWindow.parent;
        }

        private void wireupData()
        {
            UsernameTextbox.Text = userModel.username;
            PasswordTextbox.Text = userModel.password;
            isChanged = false;
        }

        private void PasswordTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isChanged = true;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextbox.Text.Length != 0)
            {
                userModel.password = PasswordTextbox.Text; 
            }
            callingForm.UserCredentials(isChanged, userModel, icon);
            this.Close();
        }
    }
}
