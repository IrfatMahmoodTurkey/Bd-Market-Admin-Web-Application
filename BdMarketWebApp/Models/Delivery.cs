using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Place Name is Required")]
        public string PlaceName { get; set; }
        [Required(ErrorMessage = "Charge is Required")]
        [Range(1, Double.MaxValue, ErrorMessage = "Range can not be 0 or negative")]
        public decimal Charge { get; set; }
        public string ActionBy { get; set; }
        public string ActionTime { get; set; }
        public string ActionDone { get; set; }
        public int State { get; set; }
        public List<OrderInfo> OrderInfos { get; set; }
    }
}
