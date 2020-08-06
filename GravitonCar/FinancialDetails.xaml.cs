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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GravitonCar
{
    /// <summary>
    /// Interaction logic for FinancialDetails.xaml
    /// </summary>
    public partial class FinancialDetails : UserControl
    {
        int i = 0;
        public FinancialDetails()
        {
            InitializeComponent();
        }

        ComboBox addLoanType(int i)

        {
           

            ComboBox LoanType = new ComboBox();
            LoanType.Name = "LoanNameTextbox" + i.ToString();
            LoanType.Width = 200;
            LoanType.Height = 30;

            return LoanType;

        }

        TextBox addLoanBankName(int i)
        {
            TextBox LoanBankName = new TextBox();
            LoanBankName.Name = "LoanBankNameTextbox" + i.ToString();
            LoanBankName.Margin = new Thickness(10);
            LoanBankName.Width = 200;
            LoanBankName.Height = 30;


            return LoanBankName;

        }

        TextBox addLoanAmount(int i)
        {
            TextBox LoanAmount = new TextBox();
            LoanAmount.Name = "LoanLoanAmountTextbox" + i.ToString();
            LoanAmount.Margin = new Thickness(10);
            LoanAmount.Width = 200;
            LoanAmount.Height = 30;


            return LoanAmount;

        }

        TextBox addLoanEmiAmount(int i)
        {
            TextBox LoanEmiAmount = new TextBox();
            LoanEmiAmount.Name = "LoanEmiAmountTextbox" + i.ToString();
            LoanEmiAmount.Margin = new Thickness(10);
            LoanEmiAmount.Width = 200;
            LoanEmiAmount.Height = 30;


            return LoanEmiAmount;

        }

        Expander addExpanderPannel(int i)
        {
            Expander LoanExpander = new Expander();
            LoanExpander.Name = "LoanExpander" + i.ToString();
            WrapPanel s = addLoanDetails(i);
            LoanExpander.Header = "Loan Number :" + (i + 1).ToString(); ;
            LoanExpander.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanExpander.FontSize = 20;
            LoanExpander.Content = s;
            LoanExpander.FontWeight = FontWeights.Light;


            return LoanExpander;

        }

        WrapPanel addLoanDetails(int i)
        {
            WrapPanel LoanDetails = new WrapPanel();
            LoanDetails.Orientation = Orientation.Vertical;
            LoanDetails.Background = new SolidColorBrush(Colors.WhiteSmoke);


            LoanDetails.Name = "LoanBankNameTextbox" + i.ToString();

            Label LoanTypeLabel = new Label();
            ComboBox LoanType = addLoanType(i);
            Label LoanBankNameLabel = new Label();
            TextBox LoanBankName = addLoanBankName(i);
            Label LoanAmountLabel = new Label();
            TextBox LoanAmount = addLoanAmount(i);
            Label LoanEmiAmountLabel = new Label();
            TextBox LoanEmiAmount = addLoanEmiAmount(i);


            LoanTypeLabel.Content = "Loan Name";
            LoanBankNameLabel.Content = "Bank Name";
            LoanAmountLabel.Content = "Loan Amount";
            LoanEmiAmountLabel.Content = "Loan EMI";



            LoanTypeLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanBankNameLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanAmountLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);
            LoanEmiAmountLabel.Foreground = new SolidColorBrush(Colors.CornflowerBlue);


            LoanTypeLabel.FontSize = 20;
            LoanBankNameLabel.FontSize = 20;
            LoanAmountLabel.FontSize = 20;
            LoanEmiAmountLabel.FontSize = 20;

            LoanTypeLabel.FontWeight = FontWeights.Light;
            LoanBankNameLabel.FontWeight = FontWeights.Light;
            LoanAmountLabel.FontWeight = FontWeights.Light;
            LoanEmiAmountLabel.FontWeight = FontWeights.Light;

            LoanType.Margin = new Thickness(5);
            LoanBankName.Margin = new Thickness(5);
            LoanAmount.Margin = new Thickness(5);
            LoanEmiAmount.Margin = new Thickness(5);
            LoanTypeLabel.Margin = new Thickness(5);
            LoanBankNameLabel.Margin = new Thickness(5);
            LoanAmountLabel.Margin = new Thickness(5);
            LoanEmiAmountLabel.Margin = new Thickness(5);



            LoanDetails.Children.Add(LoanTypeLabel);
            LoanDetails.Children.Add(LoanType);
            LoanDetails.Children.Add(LoanBankNameLabel);
            LoanDetails.Children.Add(LoanBankName);
            LoanDetails.Children.Add(LoanAmountLabel);
            LoanDetails.Children.Add(LoanAmount);
            LoanDetails.Children.Add(LoanEmiAmountLabel);
            LoanDetails.Children.Add(LoanEmiAmount);



            return LoanDetails;

        }

        private void AddLoanButton_Click(object sender, RoutedEventArgs e)
        {
            
            {
                Expander expander = addExpanderPannel(i);
                Dynamic.Children.Add(expander);
                i++;
                
            }
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            for (int j = 0;j<=i;j++)
            {
/*                string s = ((TextBox)tableLayoutPanel1.Controls["TxtBox1"]).Text; MessageBox.Show(a.ToString());
*/            }
        }
    }
}
