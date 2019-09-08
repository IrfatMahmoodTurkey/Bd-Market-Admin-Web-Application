using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BdMarketWebApp.Manager
{
    public class DesignationManager
    {
        private UnitOfWork unitOfWork;

        public DesignationManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // save designation
        public string Save(Designation designation)
        {
            if (unitOfWork.Designation.IsExists(x => x.Name == designation.Name && x.State == 1))
            {
                return BootstrapMessages.Warning("Designation already exists");
            }
            else
            {
                unitOfWork.Designation.Add(designation);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return BootstrapMessages.Success("New Designation Added Successfully");
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Add New Designation");
                }
            }
        }

        // view all designation
        public List<Designation> GetAllDesignations()
        {
            return unitOfWork.Designation.GetAllByExpression(x => x.State == 1).ToList();
        }

        // get by id
        public Designation GetById(int id)
        {
            return unitOfWork.Designation.Get(x => x.Id == id && x.State == 1);
        }
        
        // check is exists
        public bool IsExists(int id)
        {
            return unitOfWork.Designation.IsExists(x => x.Id == id && x.State == 1);
        }

        // update
        public string Update(Designation designation)
        {
            if (unitOfWork.Designation.IsExists(x =>
                x.Name == designation.Name && x.Id != designation.Id && x.State == 1))
            {
                return BootstrapMessages.Warning("Designation Already Exists");
            }
            else
            {
                unitOfWork.Designation.Update(designation);
                int updated = unitOfWork.Completed();

                if (updated > 0)
                {
                    return "1";
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Update Designation");
                }
            }
        }

        // get designation for dropdown
        public List<SelectListItem> GetDesignationForDropDown()
        {
            List<Designation> designations = GetAllDesignations();

            List<SelectListItem> selectListItems =
                designations.ConvertAll(x => new SelectListItem() {Text = x.Name, Value = x.Id.ToString()});

            return selectListItems;
        }
    }
}
