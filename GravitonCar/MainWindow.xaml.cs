using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Static base structure of the software
    /// </summary>
    public partial class MainWindow : Window,IScreenRequester
    {
        
        /// <summary>
        /// User whose session is this.
        /// </summary>
        public static UserModel user = new UserModel();
        /// <summary>
        /// Access permission of this user
        /// </summary>
        public static string userPermission;
        public static MainWindow parent;
        public MainWindow(UserModel userModel)
        {
            InitializeComponent();
            user = userModel;
            CheckPermission(user.permissions);
            InitializeMainGrid();
            GetPath();
            parent = this;
        }

        /// <summary>
        /// Sets the homepage to search screen
        /// </summary>
        private void InitializeMainGrid()
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
        }

        /// <summary>
        /// Updates the user permission to userPermission variable
        /// </summary>
        /// <param name="user_permission"></param>
        private void CheckPermission(string user_permission)
        {
            JObject permission = JObject.Parse(user_permission);
            //var obj = permission["Admin"];
            bool isAdminTrue = permission.SelectToken("Admin").Value<bool>();

            if (isAdminTrue)
            {
                userPermission = "Admin";
            }
            else
            {
                userPermission = "";
            }
        }

        /// <summary>
        /// Reads the file path from path.txt after
        /// checking whether it exists..
        /// </summary>
        private void GetPath()
        {
            if (!File.Exists("Path.txt"))
            {
                PathVariable form = new PathVariable(this);
                form.ShowDialog();
            }
            else
            {
                string line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader("Path.txt");
                    //Read the first line of text
                    line = sr.ReadLine();

                    GlobalConfig.FilePath = line;
                    //close the file
                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception " + e.Message);
                }
            }
        }

        /// <summary>
        /// Shortcut for home (Ctrl + h)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CtrShortcut1(Object sender, ExecutedRoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
        }

        /// <summary>
        /// Quit BUtton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
      
        /// <summary>
        /// Shutdown Button Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }

        public void CoApplicantForm(CarModel model)
        {
            GridPrincipal.Children.Add(new CoApplicantForm(this, model));
        }

        public void FinancialScreen(CarModel model)
        {
            GridPrincipal.Children.Add(new FinancialDetails(this, model));
        }

        public void RemoveCoApplicantScreen(UserControl control)
        {
            GridPrincipal.Children.Remove(control);
        }

        public void RemoveFinancialScreen(UserControl control)
        {
            GridPrincipal.Children.Remove(control);
        }

        public void PreviewScreen(CarModel model)
        {
            GridPrincipal.Children.Add(new Preview(this, model));
        }

        public void ApplicantForm()
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new ApplicantDetailsFormUserControl(this));
        }

        public void SetSystemPath(string path)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Path.txt");
                //Write a line of text
                sw.WriteLine(path);
                //Close the file
                sw.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Exception: " + a.Message);
            }
            finally
            {
                Debug.WriteLine("Executing finally block.");
            }
        }

        public void DisplayScreen(CarModel model)
        {
            GridPrincipal.Children.Add(new Display(this, model));
        }

        public void SearchScreen()
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
        }

        /// <summary>
        /// Admin Button Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (userPermission == "Admin")
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new AdminPanel(this));
            }
            else
            {

                
                MessageBox.Show("Access Denied");
            }
        }

        public void NewUser()
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new NewUserForm(this));
        }

        public void AdminPanel()
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new AdminPanel(this));
        }

        /// <summary>
        /// User Logged out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginForm form = new LoginForm();
            this.Close();
            form.Show();
        }

        /// <summary>
        /// For refreshing the search screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
        }

    }
}
