using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
   public class CategoryModel
    {
        /// <summary>
        /// Id Of The Category
        /// </summary>
        public int category_id { get; set; }
        /// <summary>
        /// Name Of The Category, Max Length 50
        /// </summary>
        public string category_name { get; set; }
    }
}
