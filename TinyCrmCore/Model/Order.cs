using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Core.Model;

namespace TinyCrm.Model
{
   public  class Order
    {
       public int Id { get; set; }

        public Customer customer { get; set; } 

        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Id of an order
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// DeliveryAddress of an order
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// TotalMount of an order
        /// </summary>
        public decimal TotalMount { get; set; }

        /// <summary>
        /// ProductList of an order
        /// </summary>
       
        
    }
}
