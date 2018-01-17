using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class WarehouseType
    {
        public int Id { get; set; }
        [Display(Name = "Rodzaj bazy magazynowej")]
        public string WarehouseTypeName { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}