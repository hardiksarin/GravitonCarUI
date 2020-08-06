using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class GurantorTypeModel
    {
        /// <summary>
        /// Id Of The Gurantor Type 
        /// </summary>
        public int gurantortype_id { get; set; }
        /// <summary>
        /// Name Of The Gurantor Type, Max Length 50
        /// </summary>
        public string gurantortype_name { get; set; }
    }
}
