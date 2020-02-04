using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCrm.Core.Model.Options
{
   public  class UpdateProductOptions
    {
        
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public decimal? Discount { get; set; }
    }
}
