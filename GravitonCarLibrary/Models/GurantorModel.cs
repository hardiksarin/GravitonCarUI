using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
  public  class GurantorModel
    {
        /// <summary>
        /// First Name of the gurantor,Max Length 50 
        /// </summary>
        public string gurantor_firstname { get; set; }
        /// <summary>
        /// Middle Name of the gurantor,Max Length 50 
        /// </summary>
        public string gurantor_middlename { get; set; }
        /// <summary>
        /// Last Name of the gurantor,Max Length 50 
        /// </summary>
        public string gurantor_lastname { get; set; }
        /// <summary>
        ///  Current Address Of The Gurantor, Max Length 300
        /// </summary>
        public string gurantor_currentaddress { get; set; }
        /// <summary>
        /// Mobile Number of the gurantor
        /// </summary>
        public string gurantor_mobile { get; set; }
        /// <summary>
        /// Relationship of the Applicant With the gurantor
        /// </summary>
        public string gurantor_relation { get; set; }
        /// <summary>
        /// Pan Id of the gurantor,Max Length 10
        /// </summary>
        public string gurantor_realtedpan { get; set; }
        /// <summary>
        ///  Aadhar Id of the gurantor, Fixed Length 12
        /// </summary>
        public string gurantor_realtedaadhar { get; set; }
        /// <summary>
        ///  Gurantor Type Id
        /// </summary>
        public int gurantortype_id { get; set; }
    }
}
