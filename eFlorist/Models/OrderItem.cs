using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public virtual Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public virtual Order Order { get; set; }
        public int? ItemId { get; set; }
        public int? OrderId { get; set; }
    }
}