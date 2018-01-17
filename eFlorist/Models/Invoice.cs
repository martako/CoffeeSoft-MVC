using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Display(Name = "Numer faktury")]
        public string InvoiceNo { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Florist Florist { get; set; }
        public virtual Order Order { get; set; }
        public int? WarehouseId { get; set; }
        public int? FloristId { get; set; }
    }
}