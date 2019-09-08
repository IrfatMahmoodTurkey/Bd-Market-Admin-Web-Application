using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("OrderInfo")]
        public int InfoId { get; set; }
        public OrderInfo OrderInfo { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Profit { get; set; }
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public string OrderMonth { get; set; }
        public string OrderYear { get; set; }
        public int IsNew { get; set; }
        public int IsDelivered { get; set; }
        public int IsReceived { get; set; }
        public string LastActionBy { get; set; }
        public string ActionTime { get; set; }
        public string ActionDone { get; set; }
        public int State { get; set; }
        public int IsClientState { get; set; }
    }
}
