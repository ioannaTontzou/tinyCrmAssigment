using System;
using System.Collections.Generic;
using TinyCrm.Model;
using TinyCrmCore.Model;

namespace TinyCrm.Core.Model
{
   public class Customer
    {  
        /// <summary>
        /// 
       /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public string Lastname { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Firstname { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Status { get; set; }

        public ICollection<ContactPerson> Contacts { get; set; }
        public ICollection<Order> Orders { get;  set; }

        public Customer()
        {
            Orders = new List<Order>();
            Created = DateTimeOffset.Now;
            Contacts = new List<ContactPerson>();
        }

    }
}
