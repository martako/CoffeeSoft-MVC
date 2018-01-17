using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Display(Name = "Baza magazynowa")]
        public string WarehouseName { get; set; }
        [Display(Name = "Adres")]
        public string WarehouseAddress { get; set; }
        public virtual WarehouseType WarehouseType { get; set; }
        public virtual ICollection<Order> OrderList { get; set; }
        public virtual ICollection<Invoice> InvoiceList { get; set; }
        public virtual ICollection<Florist> FloristList { get; set; }
        public int? WarehouseTypeId { get; set; }
    }
}