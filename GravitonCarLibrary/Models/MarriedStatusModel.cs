using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class MarriedStatusModel
    {
        /// <summary>
        /// Marital Status Id of the Applicant
        /// </summary>
        public int maritalstatus_id { get; set; }
        /// <summary>
        /// Maritals Status Name of the Applicant, Max Length 50
        /// </summary>
        public string maritalstatus_name { get; set; }
    }
}
