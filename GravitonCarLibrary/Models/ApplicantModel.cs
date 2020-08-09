using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class ApplicantModel
    {
        /// <summary>
        /// First Name of the Applicant,Max Length 50 
        /// </summary>
        public string applicant_firstname { get; set; }
        /// <summary>
        /// Middle Name of the Applicant,Max Length 50 
        /// </summary>
        public string applicant_middlename { get; set; }
        /// <summary>
        /// Last Name of the Applicant,Max Length 50 
        /// </summary>
        public string applicant_lastname { get; set; }
        /// <summary>
        ///  Name of the Acquaintance of the Applicant,Max Length 50 
        /// </summary>
        public string applicant_acquaintancename { get; set; }
        /// <summary>
        /// Date of Birth of the Applicant
        /// </summary>
        public string applicant_dob { get; set; }
        /// <summary>
        /// State of the Applicant
        /// </summary>
        public string applicant_state { get; set; }
        /// <summary>
        /// District of the Applicant
        /// </summary>
        public string applicant_district { get; set; }
        /// <summary>
        /// Pincode of the Applicant, Fixed Length 6
        /// </summary>
        public long applicant_pincode { get; set; }
        /// <summary>
        ///  Current Address of the Applicant,Max Length 300
        /// </summary>
        public string applicant_currentaddress { get; set; }
        /// <summary>
        /// Mobile Number of the Applicant
        /// </summary>
        public long applicant_mobile { get; set; }
        /// <summary>
        /// Office Number of the Applicant
        /// </summary>
        public long applicant_officeno { get; set; }
        /// <summary>
        /// Designation of the Applicant,Max Length 20 
        /// </summary>
        public string applicant_desgination { get; set; }
        /// <summary>
        /// Education of the Applicant,Max Length 20 
        /// </summary>
        public string applicant_education { get; set; }
        /// <summary>
        ///  Employer Name of the Applicant,Max Length 20 
        /// </summary>
        public string applicant_employername { get; set; }
        /// <summary>
        /// Office Address of the Applicant,Max Length 20 
        /// </summary>
        public string applicant_officeaddress { get; set; }
        /// <summary>
        /// Nearest Branch Of the Company To the Applicant,Max Length 20 
        /// </summary>
        public string applicant_nearestbranch { get; set; }
        /// <summary>
        /// Distance of the nearest branch of the company to the Applicant
        /// </summary>
        public int applicant_distance { get; set; }
        /// <summary>
        /// Acquaintance's id Realted to the Applicant
        /// </summary>
        public int applicant_acquaintanceid { get; set; }
        /// <summary>
        ///  Marital Status Id of the Applicant
        /// </summary>
        public int applicant_maritalstatusid { get; set; }
        /// <summary>
        /// Caste Id of the Applicant
        /// </summary>
        public int applicant_casteid { get; set; }
        /// <summary>
        /// Category Id of the Applicant
        /// </summary>
        public int applicant_categoryid { get; set; }
        /// <summary>
        /// Pan Card of the Applicant, Fixed Length 10
        /// </summary>
        public string applicant_pan { get; set; }
        /// <summary>
        ///  Aadhar Id of the Applicant, Fixed Length 12
        /// </summary>
        public string applicant_aadhar { get; set; }
    
    }
}
