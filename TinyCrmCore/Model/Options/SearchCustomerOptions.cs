﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCrm.Core.Model.Options
{
    public class SearchCustomerOptions
    {
        /// <summary>
        /// DateCreated criteria
        /// </summary>
        public DateTime DateCreated { get; set; }
       
        /// <summary>
        /// searching Vatnumber
        /// </summary>
        public string VatNumber { get; set; }
        /// <summary>
        /// searching email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTimeOffset CreatedFrom { get; set; }
        public DateTimeOffset CreatedTo { get; set; }
    }
}
