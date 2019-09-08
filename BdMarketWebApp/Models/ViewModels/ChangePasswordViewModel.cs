using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Old Password Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password Required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Re Enter New Password Required")]
        public string ReEnterPassword { get; set; }
    }
}
