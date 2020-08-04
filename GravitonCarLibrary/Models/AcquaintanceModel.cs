using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class AcquaintanceModel
    {
        /// <summary>
        /// Id Of The Acquaintance
        /// </summary>
        public int acquaintance_id { get; set; }
        /// <summary>
        /// Name Of The Acquaintance, Max Length 50
        /// </summary>
        public string acquaintance_name { get; set; }
    }
}
