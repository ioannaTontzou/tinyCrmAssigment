using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Model.Options
{
  public  class SearchProductOption
    {
        /// <summary>
        /// search product by Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// search product by Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// search product by Category
        /// </summary>
        public ProductCategory Category { get; set; }


    }
}
