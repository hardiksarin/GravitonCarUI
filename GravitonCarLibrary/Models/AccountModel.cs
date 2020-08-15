using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class AccountModel
    {

        /// <summary>
        /// Name Of The Bank
        /// </summary>
        public string account_bankname { get; set; }
        /// <summary>
        /// IFSC of the Bank account
        /// </summary>
        public string account_ifsc { get; set; }
        /// <summary>
        /// Account Number of the Bank account, Max Length 50
        /// </summary>
        public string account_number { get; set; }
        /// <summary>
        /// In Hand Salary of the Applicant, Max Length 30
        /// </summary>
        public int account_inhandsalary { get; set; }
        /// <summary>
        /// Pan Related To the Applicant, Fix length 10
        /// </summary>
        public string account_realtedpan { get; set; }
        /// <summary>
        /// Aadhar Related to the Applicant,Fix length 12
        /// </summary>
        public string account_realtedaadhar { get; set; }
        
       
    }
}
