using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<CoffeeShop> CoffeeShops { get; set; }
        public int? ItemTypeId { get; set; }
    }
}