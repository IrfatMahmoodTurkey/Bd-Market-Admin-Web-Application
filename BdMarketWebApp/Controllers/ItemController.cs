using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Manager;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BdMarketWebApp.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ProductManager productManager;
        private CategoryManager categoryManager;

        public ItemController()
        {
            productManager = new ProductManager();
            categoryManager = new CategoryManager();
        }

        // get top items
        [Route("TopItems")]
        [HttpGet]
        public object TopItems()
        {
            List<ProductViewModel> items = productManager.TakeTopItems(8);
            return items;
        }

        // get all items
        [Route("AllItems")]
        [HttpGet]
        public object AllItems()
        {
            List<ProductViewModel> items = productManager.GetAllProducts();
            return items;
        }

        // get product details
        [Route("Details/{id}")]
        [HttpGet]
        public object Details(int id)
        {
            ProductViewModel item = productManager.GetProductByIdForDetails(id);
            return item;
        }

        // get related product by category
        [Route("Related/{id}")]
        [HttpGet]
        public object GetRelatedItems(int id)
        {
            List<ProductViewModel> items = productManager.GetRelatedProductsByCategoryId(id, 3);
            return items;
        }

        // get categories for website
        [Route("Categories")]
        [HttpGet]
        public object Categories()
        {
            List<Category> categories = categoryManager.GetAll();
            return categories;
        }

        //get categories by category id
        [Route("Category/{id}")]
        [HttpGet]
        public object ItemsWithCategory(int id)
        {
            List<ProductViewModel> items = productManager.GetAllItemsByCategory(id);
            return items;
        }

        // search by title
        [Route("Search/{title}")]
        [HttpGet]
        public object ItemsByTitle(string title)
        {
            List<ProductViewModel> items = productManager.SearchItem(title);
            return items;
        }

        //search by category and title
        [Route("Search/{id}/{title}")]
        [HttpGet]
        public object ItemsByCategoryAndTitle(int id, string title)
        {
            List<ProductViewModel> items = productManager.SearchByTitleAndCategory(title, id);
            return items;
        }
    }
}