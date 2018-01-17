using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class StatusType
    {
        public int Id { get; set; }
        [Display(Name = "Status zamówienia")]
        public string StatusName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}