using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class ProgressModel
    {
        /// <summary>
        /// Id Of The Progress 
        /// </summary>
        public int progress_id { get; set; }
        /// <summary>
        /// Name Of The Progress, Max Length 50
        /// </summary>
        public string progress_name { get; set; }
    }
}
