using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            GlobalConfig.InitializeConnections();
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new ApplicantDetailsFormUserControl(this));
        }



        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        public void CtrShortcut1(Object sender, ExecutedRoutedEventArgs e)
        {
            ButtonPopUpQuit.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ButtonPopUpQuit_Click(object sender, RoutedEventArgs e)
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
    }
}
