using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class KYCLogModel
    {
        public int log_id { get; set; }
        public int user_id { get; set; }
        public string related_aadhar { get; set; }
        public string related_pan { get; set; }
        public string kyc_date { get; set; }
    }
}
