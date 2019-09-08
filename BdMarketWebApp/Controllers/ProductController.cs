using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Manager;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BdMarketWebApp.Controllers
{
    public class ProductController : Controller
    {
        private CategoryManager categoryManager;
        private ProductManager productManager;
        private FTPFileUpload ftpFileUpload;
        private UserAccessManager userAccessManager;

        public ProductController()
        {
            categoryManager = new CategoryManager();
            productManager = new ProductManager();
            ftpFileUpload = new FTPFileUpload();
            userAccessManager = new UserAccessManager();
        }

        // add new product
        [HttpGet]
        public IActionResult Add()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        [HttpPost]
        public IActionResult Add(Product product, IFormFile picture)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (picture != null)
                    {
                        if (ModelState.IsValid)
                        {
                            DateTime entryDate = DateTime.Parse(product.EntryDate);

                            product.EntryMonth = entryDate.Month;
                            product.EntryYear = entryDate.Year;

                            product.Profit = product.SellPrice - product.BasePrice;

                            product.ActionBy = employee.UserName;
                            product.ActionDone = ActionAttributes.ActionInsert;
                            product.ActionTime = DateTime.Now.ToString("F");

                            string fileName = Guid.NewGuid().ToString() + "_" + picture.FileName;
                            product.PictureUrl = "http://www.ecom.somee.com/Pictures/" + fileName;
                            product.State = 1;

                            string uploadPictureMessage = ftpFileUpload.UploadProductPicture(picture, fileName);

                            if (uploadPictureMessage.Equals("1"))
                            {
                                ViewData["Message"] = productManager.Save(product);
                                ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                                ModelState.Clear();
                                return View();
                            }
                            else
                            {
                                ViewData["Message"] = BootstrapMessages.Failed("Data Not Saved for failure of Picture Upload. Reason: " + uploadPictureMessage);
                                ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                                ModelState.Clear();
                                return View();
                            }
                        }
                        else
                        {
                            ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");
                            ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                            return View();
                        }
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Failed("Must Browse Product Picture");
                        ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                        return View();
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view all
        [HttpGet]
        public IActionResult ViewAll()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    ViewBag.Products = productManager.GetAllProducts();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (productManager.IsProductExists(id))
                    {
                        ProductViewModel productViewModel = productManager.GetProductByIdForDetails(id);

                        Product product = productManager.ConvertViewModelToModel(productViewModel);

                        ViewData["CategoryName"] = productViewModel.CategoryName;
                        ViewData["Picture"] = productViewModel.PictureUrl;

                        return View(product);
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // update product info
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (productManager.IsProductExists(id))
                    {
                        Product product = productManager.GetById(id);
                        ViewBag.Categories = categoryManager.GetCategoriesForDropDown();

                        return View(product);
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile picture)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (productManager.IsProductExists(product.Id))
                    {
                        if (ModelState.IsValid)
                        {
                            DateTime entryDate = DateTime.Parse(product.EntryDate);

                            product.EntryMonth = entryDate.Month;
                            product.EntryYear = entryDate.Year;

                            product.Profit = product.SellPrice - product.BasePrice;

                            product.ActionBy = employee.UserName;
                            product.ActionDone = ActionAttributes.ActionUpdate;
                            product.ActionTime = DateTime.Now.ToString("F");

                            product.State = 1;

                            if (picture != null)
                            {
                                string fileName = Guid.NewGuid().ToString() + "_" + picture.FileName;
                                product.PictureUrl = " http://www.ecom.somee.com/Pictures/" + fileName;

                                ftpFileUpload.UploadProductPicture(picture, fileName);

                                string updated = productManager.Update(product);

                                if (updated.Equals("1"))
                                {
                                    return RedirectToAction("ViewAll", "Product");
                                }
                                else
                                {
                                    Product productBack = productManager.GetById(product.Id);
                                    ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                                    ViewData["Message"] = updated;

                                    return View(productBack);
                                }
                            }
                            else
                            {
                                string updated = productManager.Update(product);

                                if (updated.Equals("1"))
                                {
                                    return RedirectToAction("ViewAll", "Product");
                                }
                                else
                                {
                                    Product productBack = productManager.GetById(product.Id);
                                    ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                                    ViewData["Message"] = updated;

                                    return View(productBack);
                                }
                            }
                        }
                        else
                        {
                            Product productBack = productManager.GetById(product.Id);
                            ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                            ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");

                            return View(productBack);
                        }
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // remove
        public IActionResult Remove(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (productManager.IsProductExists(id))
                    {
                        Product product = productManager.GetById(id);

                        product.ActionBy = employee.UserName;
                        product.ActionDone = ActionAttributes.ActionRemove;
                        product.ActionTime = DateTime.Now.ToString("F");
                        product.State = 0;

                        productManager.Remove(product);

                        return RedirectToAction("ViewAll", "Product");
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // stock new items
        [HttpGet]
        public IActionResult StockIn(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (productManager.IsProductExists(id))
                    {
                        Product item = productManager.GetById(id);

                        ViewData["ProductId"] = item.Id;
                        ViewData["ProductTitle"] = item.ProductTitle;
                        ViewData["PrevQuantity"] = item.Quantity;

                        return View();
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        [HttpPost]
        public IActionResult StockIn(int quantity, int productId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 6))
                {
                    if (productManager.IsProductExists(productId))
                    {
                        if (quantity > 1 || quantity < 10000000)
                        {
                            Product item = productManager.GetById(productId);

                            item.ActionBy = employee.UserName;
                            item.ActionDone = ActionAttributes.ActionUpdate;
                            item.ActionTime = DateTime.Now.ToString("F");
                            item.State = 1;

                            item.Quantity = item.Quantity + quantity;

                            string updated = productManager.Update(item);

                            if (updated.Equals("1"))
                            {
                                return RedirectToAction("ViewAll", "Product");
                            }
                            else
                            {
                                Product itemData = productManager.GetById(productId);

                                ViewData["ProductId"] = itemData.Id;
                                ViewData["ProductTitle"] = itemData.ProductTitle;
                                ViewData["PrevQuantity"] = itemData.Quantity;
                                ViewData["Message"] = updated;

                                return View();
                            }
                        }
                        else
                        {
                            Product item = productManager.GetById(productId);

                            ViewData["ProductId"] = item.Id;
                            ViewData["ProductTitle"] = item.ProductTitle;
                            ViewData["PrevQuantity"] = item.Quantity;
                            ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");

                            return View();
                        }
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }
    }
}