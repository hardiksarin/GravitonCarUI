using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class DocumentTypeModel
    {
        /// <summary>
        /// Id Of The Document Type 
        /// </summary>
        public int documenttype_id { get; set; }
        /// <summary>
        /// Name Of The Document Type, Max Length 50
        /// </summary>
        public string documenttype_name { get; set; }
    }
}
