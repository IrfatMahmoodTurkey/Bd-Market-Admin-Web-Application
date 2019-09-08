using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string VerificationCode { get; set; }
        public int Verify { get; set; }
        public string AccountCreatingTime { get; set; }
        public int State { get; set; }
        public List<OrderInfo> OrderInfos { get; set; }
        public List<UserAccess> UserAccesses { get; set; }
    }
}
