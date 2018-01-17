using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeSoft.Models
{
    public class Truck
    {
        public int Id { get; set; }
        [Display(Name = "Pojazd")]
        public string TruckName { get; set; }
        public virtual TruckType TruckType { get; set; }
        public string Brand { get; set; }
        public string RegistrationNo { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public int? TruckTypeId { get; set; }
    }
}