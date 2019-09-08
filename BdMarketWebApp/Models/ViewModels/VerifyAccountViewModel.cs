using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models.ViewModels
{
    public class VerifyAccountViewModel
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
