using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;

namespace BdMarketWebApp.Manager
{
    public class AuthManager
    {
        private UnitOfWork unitOfWork;

        public AuthManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // log in user
        public Employee LogIn(LoginViewModel model)
        {
            Employee employee = unitOfWork.Employee.Get(x =>
                x.UserName == model.UserName && x.Password == model.Password && x.State == 1);

            return employee;
        }
    }
}
