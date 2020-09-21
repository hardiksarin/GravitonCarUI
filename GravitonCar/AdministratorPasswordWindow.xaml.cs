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
    /// Interaction logic for AdministratorPasswordWindow.xaml
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


        private void getAdminData()
        {
            string password = AdminPasswordTextBox.Password;
            callingForm.GetAdminPassword(password , pack);
            this.Close();
            /*if (password.Equals(userModel.password))
            {
                callingForm.GetAdminPassword(true, pack);
                this.Close();
            }
            else
            {
                callingForm.GetAdminPassword(false, pack);
                this.Close();
            }*/
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            getAdminData();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
