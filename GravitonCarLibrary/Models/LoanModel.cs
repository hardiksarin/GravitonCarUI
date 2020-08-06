using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class LoanModel
    {
        /// <summary>
        /// Id Of The Loan 
        /// </summary>
        public int loan_id { get; set; }
        /// <summary>
        /// Name Of The Bank which Issued the Loan, Max Length 50
        /// </summary>
        public string loan_bankname { get; set; }
        /// <summary>
        /// Amount Of the Loan
        /// </summary>
        public int loan_amount { get; set; }
        /// <summary>
        /// Emi of the Loan
        /// </summary>
        public int loan_emi { get; set; }
        /// <summary>
        /// Closure Date of the Loan
        /// </summary>
        public int loan_closuredate { get; set; }
        /// <summary>
        /// Type Of Loan
        /// </summary>
        public int loan_type { get; set; }
        /// <summary>
        /// Pan Related To the Loan, Fix length 10
        /// </summary>
        public string loan_relatedpan { get; set; }
        /// <summary>
        /// Aadhar Related to the Loan,Fix length 12
        /// </summary>
        public string loan_relatedaadhar { get; set; }


    }
}
