using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GravitonCar.Models
{
    /// <summary>
    /// New Loan Model to add previous existinng loans.
    /// </summary>
    public class NewLoanModel
    {
        /// <summary>
        /// Loan Number of previous Loans.
        /// </summary>
        public int LoanNumber { get; set; }
        /// <summary>
        /// XAML Id name for the expander
        /// </summary>
        public string LoanExpanderName { get; set; }
        /// <summary>
        /// Loan Type Label
        /// </summary>
        public ComboBox LoanTypeLabel { get; set; } = new ComboBox();
        /// <summary>
        /// Type of Loan taken
        /// </summary>
        public int LoanType { get; set; }
        /// <summary>
        /// Loan Bank Name Label
        /// </summary>
        public TextBox LoanBankNameLabel { get; set; } = new TextBox();
        /// <summary>
        /// Name of the bank where Loan exists.
        /// </summary>
        public string LoanBankName { get; set; }
        /// <summary>
        /// Loan Amount Label
        /// </summary>
        public TextBox LoanAmountLabel { get; set; } = new TextBox();
        /// <summary>
        /// Amount taken as loan
        /// </summary>
        public double LoanAmount { get; set; }
        /// <summary>
        /// Loan Emi Amount Label
        /// </summary>
        public TextBox LoanEmiAmountLabel { get; set; } = new TextBox();
        /// <summary>
        /// Pending Emi Amount
        /// </summary>
        public double LoanEmiAmount { get; set; }
    }
}
