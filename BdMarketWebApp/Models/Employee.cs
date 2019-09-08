using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [ForeignKey("Designation")]
        [Required(ErrorMessage = "Designation Required")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public string ProfilePicture { get; set; }
        public string Password { get; set; }
        public string ActionBy { get; set; }
        public string ActionDone { get; set; }
        public string ActionTime { get; set; }
        public int State { get; set; }
    }
}
