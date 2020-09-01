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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IScreenRequester
    {
        JObject permission;
        public static UserModel user = new UserModel();
        public static string userPermission;
        public static MainWindow parent;
        public MainWindow(UserModel userModel)
        {
            InitializeComponent();
            user = userModel;
            CheckPermission();
            //GlobalConfig.InitializeConnections();
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
            GetPath();
            parent = this;
        }

        private void CheckPermission()
        {
            permission = JObject.Parse(user.permissions);
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
                finally
                {
                    Debug.WriteLine("Executing finally block.");
                }
            }
        }

      /*  private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
*/
        public void CtrShortcut1(Object sender, ExecutedRoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
      
      
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Do you want to close?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }

        public void CoApplicantForm(CarModel model)
        {
            //GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new CoApplicantForm(this, model));
        }

        public void FinancialScreen(CarModel model)
        {
            //GridPrincipal.Children.Clear();
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

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginForm form = new LoginForm();
            this.Close();
            form.Show();
        }

        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Search(this));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
