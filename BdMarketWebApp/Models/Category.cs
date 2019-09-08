using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string Name { get; set; }
        public string ActionBy { get; set; }
        public string ActionName { get; set; }
        public string ActionTime { get; set; }
        public int State { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
