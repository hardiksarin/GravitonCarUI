using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class DocumentModel
    {
        /// <summary>
        /// Id Of The Document 
        /// </summary>
        public int progress_id { get; set; } = 1;
        /// <summary>
        /// Progress Id 
        /// </summary>
        public int document_id { get; set; }
        /// <summary>
        /// Remark On The Document , Max Length 100
        /// </summary>
        public string document_remark { get; set; }
        /// <summary>
        /// Cibil score of the applicant, range 300 to 900
        /// </summary>
        public int document_cibil { get; set; }
        /// <summary>
        /// Optional Document
        /// </summary>
        public string document_optional { get; set; }
        /// <summary>
        /// Aadhar Number Assocaited with the Document, Fixed Length 12
        /// </summary>
        public string document_aadhar { get; set; }
        /// <summary>
        /// Pan Number Assocaited with the Document, Fixed Length 10
        /// </summary>
        public string document_pan { get; set; }
    }
}
