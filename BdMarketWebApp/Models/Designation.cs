using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class Designation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Designation Name")]
        public string Name { get; set; }
        public string ActionBy { get; set; }
        public string ActionDone { get; set; }
        public string ActionTime { get; set; }
        public int State { get; set; }
    }
}
