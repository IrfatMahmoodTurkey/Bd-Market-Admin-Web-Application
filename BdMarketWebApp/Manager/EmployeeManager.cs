using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using BdMarketWebApp.Utility;

namespace BdMarketWebApp.Manager
{
    public class EmployeeManager
    {
        private UnitOfWork unitOfWork;

        public EmployeeManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // save employee
        public string Save(Employee employee)
        {
            if (unitOfWork.Employee.IsExists(x => x.UserName == employee.UserName && x.State == 1))
            {
                return BootstrapMessages.Warning("Same UserName is already Exists");
            }
            else
            {
                unitOfWork.Employee.Add(employee);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return BootstrapMessages.Success("New Employee Saved Successfully");
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to save new employee");
                }
            }
        }
        
        // view employees
        public List<EmployeeViewModel> GetAllEmployees()
        {
            return unitOfWork.Employee.GetAllEmployees();
        }

        // get by id
        public Employee GetEmployeeById(int id)
        {
            return unitOfWork.Employee.Get(x => x.Id == id && x.State == 1);
        }

        // update
        public string Update(Employee employee)
        {
            unitOfWork.Employee.Update(employee);
            int rowsAffected = unitOfWork.Completed();

            if (rowsAffected > 0)
            {
                return "1";
            }
            else
            {
                return BootstrapMessages.Failed("Failed to Update Employee");
            }
        }

        // is id exists
        public bool IsIdExists(int id)
        {
            return unitOfWork.Employee.IsExists(x => x.Id == id && x.State == 1);
        }
    }
}
