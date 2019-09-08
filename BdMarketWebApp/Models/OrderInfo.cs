using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        [ForeignKey("Delivery")]
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int IsHomeDelivery { get; set; }
        public decimal DeliveryCharge { get; set; }
        [ForeignKey("User")]
        public int ActionById { get; set; }
        public User User { get; set; }
        public string ActionTime { get; set; }
        public int State { get; set; }
        public int IsClientState { get; set; }
        public List<Order> Orders { get; set; }
    }
}
