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
    public class CategoryManager
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        // save category
        public string Add(Category category)
        {
            if (unitOfWork.Category.IsExists(x => x.Name == category.Name && x.State == 1))
            {
                return BootstrapMessages.Warning("Category Already Exists");
            }
            else
            {
                unitOfWork.Category.Add(category);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return BootstrapMessages.Success("Added New Category");
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Add New Category");
                }
            }
        }

        // get all category
        public List<Category> GetAll()
        {
            return unitOfWork.Category.GetAllByExpression(x => x.State == 1).ToList();
        }

        // get by id
        public Category GetCategoryById(int id)
        {
            return unitOfWork.Category.Get(x => x.Id == id && x.State == 1);
        }

        // check is exists
        public bool IsExists(int id)
        {
            return unitOfWork.Category.IsExists(x => x.Id == id && x.State == 1);
        }

        // update
        public string Update(Category category)
        {
            if (unitOfWork.Category.IsExists(x => x.Name == category.Name && x.State == 1 && x.Id != category.Id))
            {
                return BootstrapMessages.Warning("Category Already Exists");
            }
            else
            {
                unitOfWork.Category.Update(category);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return "1";
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Update New Category");
                }
            }
        }

        // get category for dropdown
        public List<SelectListItem> GetCategoriesForDropDown()
        {
            List<Category> categories = GetAll();

            List<SelectListItem> selectListItems =
                categories.ConvertAll(x => new SelectListItem() {Text = x.Name, Value = x.Id.ToString()});

            return selectListItems;
        }
    }
}
