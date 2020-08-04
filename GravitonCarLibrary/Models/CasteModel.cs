using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class CasteModel
    {
        /// <summary>
        /// Id Of The Caste
        /// </summary>
        public int caste_id { get; set; }
        /// <summary>
        /// Name Of The Caste, Max Length 50
        /// </summary>
        public string caste_name { get; set; }
    }
}
