using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Email Required")]
        [EmailAddress(ErrorMessage = "Email Address Invalid")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "User Phone Number Required")]
        public string Phone { get; set; }
        public string VerificationCode { get; set; }
        public int Verify { get; set; }
        public string AccountCreatingTime { get; set; }
        public int State { get; set; }
    }
}
