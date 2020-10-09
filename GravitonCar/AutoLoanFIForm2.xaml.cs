using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AutoLoanFIForm2.xaml
    /// </summary>
    public partial class AutoLoanFIForm2 : UserControl
    {
        string filepath = "";

        public AutoLoanFIForm2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
           
            if (op.ShowDialog() == true)
            {
                filepath = op.FileName;
                Process fileopener = new Process();
                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + filepath + "\"";
                yay.Foreground = new SolidColorBrush(Colors.LightGreen);
                yay.Kind = MaterialDesignThemes.Wpf.PackIconKind.Tick;
                /*fileopener.Start(); Image image = new Image();
                image.Source = new BitmapImage(new Uri(filepath));
                image.Width = 250;
                image.Height = 250;
                ImagePannel.Children.Add(image);*/
            }

        }
    }
}
