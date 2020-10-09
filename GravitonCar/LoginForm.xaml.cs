using GravitonCar.Models;
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
    /// Login Handler Class
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
            GlobalConfig.InitializeConnections();
        }

        /// <summary>
        /// Quit Button
        /// Closes the complete software after confirming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }

        /// <summary>
        ///Login Button Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Get User MOdel From Login credentials
            //Validate user model

            UserModel user = new UserModel();
            user = ProcessLogin();

            ValidateUser(user);
        }

        /// <summary>
        /// Validates User and navigate to homepage
        /// </summary>
        /// <param name="user"></param>
        private void ValidateUser(UserModel user)
        {
            if (user == null)
            {
                //Incorrect Username or Password
                SnackbarTwo.IsActive = true;
                SnackbarTwo.MessageQueue.Enqueue(" Incorrect Username or Password", null,
                    null,
                    null,
                    false,
                    true,
                    TimeSpan.FromSeconds(5));
            }
            else
            {
                MainWindow form = new MainWindow(user);
                this.Close();
                //form.Closed += (s, args) => this.Close();
                form.Show();
            }
        }

        /// <summary>
        /// Login Button
        /// Sends User and Password for verification
        /// Recieves User model if credentials match in database
        /// </summary>
        /// <returns></returns>
        private UserModel ProcessLogin()
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Password;
            UserModel user = new UserModel();
            LoginCredentials loginCredentials = new LoginCredentials(username, password);

            user = GlobalConfig.Connection.GetUsermodelAPI(loginCredentials);

            return user;
        }
    }
}
