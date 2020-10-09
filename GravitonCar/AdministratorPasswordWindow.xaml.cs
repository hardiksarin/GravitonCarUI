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
    /// Gets the admin password and returns with it
    /// </summary>
    public partial class AdministratorPasswordWindow : Window
    {
        IAdminPasswordRequester callingForm;
        UserModel userModel = new UserModel();
        PackIcon pack = new PackIcon();
        public AdministratorPasswordWindow(IAdminPasswordRequester caller, UserModel user, PackIcon icon)
        {
            InitializeComponent();
            callingForm = caller;
            userModel = user;
            pack = icon;
            this.Owner = MainWindow.parent;
        }

        /// <summary>
        /// Gets password and returns to Admin Panel
        /// </summary>
        private void getAdminData()
        {
            string password = AdminPasswordTextBox.Password;
            callingForm.GetAdminPassword(password , pack);
            this.Close();
        }

        //On Submit
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            getAdminData();
        }

        //On Quit
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
