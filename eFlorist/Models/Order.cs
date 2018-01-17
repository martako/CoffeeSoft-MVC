using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeSoft.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Numer zamówienia")]
        public string OrderNo { get; set; }
        [Display(Name = "Data zamówienia")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime OrderCreatedDate { get; set; }
        public virtual StatusType OrderStatus { get; set; }
        public virtual Truck OrderTruck { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual CoffeeShop CoffeeShop { get; set; }
        public virtual PaymentType OrderPayment { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [Display(Name = "Zaakceptowane")]
        public bool IsAccepted { get; set; }
        [Display(Name = "Odrzucone")]
        public bool IsRejected { get; set; }
        public int? OrderStatusId { get; set; }
        public int? OrderTruckId { get; set; }
        public int? WarehouseId { get; set; }
        public int? OrderPaymentId { get; set; }
        public int? CoffeeShopId { get; set; }
        public int? InvoiceId { get; set; }
    }
}