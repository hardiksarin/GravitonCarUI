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
using System.Windows.Shapes;

namespace GravitonCar
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
            GlobalConfig.InitializeConnections();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Password;

            UserModel user = new UserModel();

            user = GlobalConfig.Connection.GetUserModel(username, password);

            if(user == null)
            {
                //Incorrect Username or Password
                MessageBox.Show("Incorrect Username or Password");
            }
            else
            {
                MainWindow form = new MainWindow(user);
                this.Close();
                //form.Closed += (s, args) => this.Close();
                form.Show();
            }
        }
    }
}
