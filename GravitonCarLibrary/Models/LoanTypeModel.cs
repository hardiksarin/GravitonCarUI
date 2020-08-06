using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class LoanTypeModel
    {
        /// <summary>
        /// Id Of The Loan Type
        /// </summary>
        public int loantype_id { get; set; }
        /// <summary>
        /// Name Of The Loan Type, Max Length 50
        /// </summary>
        public string loantype_name { get; set; }
    }
}
