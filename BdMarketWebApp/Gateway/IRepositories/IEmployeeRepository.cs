using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;

namespace BdMarketWebApp.Gateway.IRepositories
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        int Rows();
        List<EmployeeViewModel> GetAllEmployees();
    }
}
