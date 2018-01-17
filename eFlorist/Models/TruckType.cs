using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class TruckType
    {
        public int Id { get; set; }
        public string TruckTypeName { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}