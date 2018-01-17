using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class ItemType
    {
        public int Id { get; set; }
        public string ItemsName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}