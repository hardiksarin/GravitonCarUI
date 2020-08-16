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
    /// Interaction logic for PathVariable.xaml
    /// </summary>
    public partial class PathVariable : Window
    {
        IScreenRequester callingForm;
        public PathVariable(IScreenRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
        }

        private void GetPath()
        {
            string temp = SystemPath.Text;
            callingForm.SetSystemPath(temp);
        }

        private void SystemPath_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                GetPath();
                this.Close();
            }
        }
    }
}
