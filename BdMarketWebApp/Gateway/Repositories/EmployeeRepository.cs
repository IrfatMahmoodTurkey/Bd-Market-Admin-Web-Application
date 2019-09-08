using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.Context;
using BdMarketWebApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BdMarketWebApp.Gateway.Repositories
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }

        public int Rows()
        {
            return context.Employees.Where(x => x.State == 1).ToList().Count;
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            var query = context.Employees.Include(x => x.Designation).Where(x => x.State == 1);
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var data in query)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();

                employeeViewModel.Id = data.Id;
                employeeViewModel.Name = data.Name;
                employeeViewModel.UserName = data.UserName;
                employeeViewModel.Email = data.Email;
                employeeViewModel.Phone = data.Phone;
                employeeViewModel.Address = data.Address;
                employeeViewModel.DesignationName = data.Designation.Name;
                employeeViewModel.DesignationId = data.Designation.Id;
                employeeViewModel.Password = data.Password;
                employeeViewModel.ProfilePicture = data.ProfilePicture;
                employeeViewModel.ActionBy = data.ActionBy;
                employeeViewModel.ActionDone = data.ActionDone;
                employeeViewModel.ActionTime = data.ActionTime;

                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }
    }
}
