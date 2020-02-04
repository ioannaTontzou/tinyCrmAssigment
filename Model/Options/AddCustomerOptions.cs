using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCrm.Model.Options
{
    public class AddCustomerOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email {get; set;}

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

    }
}
