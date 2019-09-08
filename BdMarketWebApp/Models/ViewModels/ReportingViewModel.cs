using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models.ViewModels
{
    public class ReportingViewModel
    {
        public decimal Total { get; set; }
        public decimal Profit { get; set; }
        public decimal Quantity { get; set; }
        public decimal DeliveryCharge { get; set; }
        public List<OrderItemViewModel> OrderItemViewModels { get; set; }
        public List<decimal> Profits { get; set; }
        public List<decimal> Totals { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
