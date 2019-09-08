using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Entry Date is Required")]
        public string EntryDate { get; set; }
        public int EntryMonth { get; set; }
        public int EntryYear { get; set; }
        [Required(ErrorMessage = "Base Price is Required")]
        [Range(0.00, Double.MaxValue, ErrorMessage = "Price must be non negative")]
        public decimal BasePrice { get; set; }
        public decimal Profit { get; set; }
        [Required(ErrorMessage = "Sell Price is Required")]
        [Range(0.00, Double.MaxValue, ErrorMessage = "Price must be non negative")]
        public decimal SellPrice { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Quantity must be non negative")]
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string ActionBy { get; set; }
        public string ActionDone { get; set; }
        public string ActionTime { get; set; }
        public int State { get; set; }
        public List<Order> Orders { get; set; }
    }
}
