using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class Florist
    {
        public int Id { get; set; }
        [Display(Name = "Kwiaciarnia")]
        public string FloristName { get; set; }
        [Display(Name = "Adres")]
        public string FloristAddress { get; set; }
        public virtual ICollection<Item> ItemsList { get; set; }
        public virtual ICollection<Order> OrderList { get; set; }
        public virtual ICollection<Invoice> InvoiceList { get; set; }
        public virtual ICollection<Warehouse> WarehouseList { get; set; }
    }
}