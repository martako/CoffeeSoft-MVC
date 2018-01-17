using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Display(Name = "Płatność")]
        public string PaymentName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}