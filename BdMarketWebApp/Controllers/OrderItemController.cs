using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Manager;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Rotativa;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace BdMarketWebApp.Controllers
{
    public class OrderItemController : Controller
    {
        private OrderManager orderManager;
        private ProductManager productManager;
        private UserAccessManager userAccessManager;
        public OrderItemController()
        {
            orderManager = new OrderManager();
            productManager = new ProductManager();
            userAccessManager = new UserAccessManager();
        }

        // show new ordered items
        [HttpGet]
        public IActionResult NewOrdered()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    ViewBag.Orders = orderManager.GetNewOrderedProducts();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // receive order
        [HttpGet]
        public IActionResult ReceiveOrder(int orderId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    Order order = orderManager.GetByIdForOrder(orderId);

                    if (order != null)
                    {
                        if (order.IsReceived == 0)
                        {
                            order.IsReceived = 1;
                            order.LastActionBy = employee.UserName;
                            order.ActionDone = ActionAttributes.ActionUpdate;
                            order.ActionTime = DateTime.Now.ToString("F");

                            orderManager.Update(order);

                            return RedirectToAction("NewOrdered", "OrderItem");
                        }
                        else
                        {
                            return NotFound("404- Not Found");
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

        // deliver order with make it old
        [HttpGet]
        public IActionResult DeliverOrder(int orderId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    Order order = orderManager.GetByIdForOrder(orderId);

                    if (order != null)
                    {
                        if (order.IsReceived == 1)
                        {
                            order.IsDelivered = 1;
                            order.IsNew = 0;
                            order.LastActionBy = employee.UserName;
                            order.ActionDone = ActionAttributes.ActionUpdate;
                            order.ActionTime = DateTime.Now.ToString("F");

                            Product product = productManager.GetById(order.ProductId);

                            if (product.Quantity > order.Quantity)
                            {
                                product.Quantity = product.Quantity - order.Quantity;
                                product.ActionBy = employee.UserName;
                                product.ActionTime = DateTime.Now.ToString("F");
                                product.ActionDone = ActionAttributes.ActionUpdate;

                                string updateMessage = productManager.Update(product);

                                if (updateMessage.Equals("1"))
                                {
                                    orderManager.Update(order);
                                }
                            }

                            return RedirectToAction("NewOrdered", "OrderItem");
                        }
                        else
                        {
                            return NotFound("404- Not Found");
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

        // remove as new
        [HttpGet]
        public IActionResult RemoveAsNew(int orderId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    Order order = orderManager.GetByIdForOrder(orderId);

                    if (order != null)
                    {
                        if (order.IsNew == 1)
                        {
                            order.IsNew = 0;
                            order.LastActionBy = employee.UserName;
                            order.ActionDone = ActionAttributes.ActionUpdate;
                            order.ActionTime = DateTime.Now.ToString("F");

                            orderManager.Update(order);

                            return RedirectToAction("NewOrdered", "OrderItem");
                        }
                        else
                        {
                            return NotFound("404- Not Found");
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

        // view all orders
        [HttpGet]
        public IActionResult ViewAllReceivedOrder()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    ViewBag.Orders = orderManager.GetDeliveredItems();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // reset as order state
        [HttpGet]
        public IActionResult ResetAsOrderState(int orderId, int go)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    Order order = orderManager.GetByIdForOrder(orderId);

                    if (order != null)
                    {
                        if (order.IsNew == 0 || order.IsReceived == 1 || order.IsDelivered == 1)
                        {
                            order.IsNew = 1;
                            order.IsDelivered = 0;
                            order.IsReceived = 0;
                            order.LastActionBy = "Client";
                            order.ActionTime = DateTime.Now.ToString("F");
                            order.ActionDone = "ORDER";

                            orderManager.Update(order);

                            if (go == 1)
                            {
                                return RedirectToAction("ViewAllReceivedOrder", "OrderItem");
                            }
                            else if (go == 2)
                            {
                                return RedirectToAction("ViewRejectedOrders", "OrderItem");
                            }
                            else if (go == 3)
                            {
                                return RedirectToAction("ViewAllOrders", "OrderItem");
                            }
                            else
                            {
                                return RedirectToAction("ViewAllOrders", "OrderItem");
                            }
                        }
                        else
                        {
                            return NotFound("404- Not Found");
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

        // view order details
        [HttpGet]
        public IActionResult ViewOrderDetails(int infoId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    OrderInfoViewModel orderInfo = orderManager.GetOrderDetailsByInfoId(infoId);

                    if (orderInfo != null)
                    {
                        ViewBag.OrderInfo = orderInfo;
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

        // print billing info
        public IActionResult PrintBillingInfo(int infoId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    OrderInfoViewModel orderInfo = orderManager.GetOrderDetailsByInfoId(infoId);

                    if (orderInfo != null)
                    {
                        return new ViewAsPdf("PrintBillingInfo", orderInfo)
                        {
                            FileName = orderInfo.FirstName+"-"+orderInfo.LastName+"'s_Bill.pdf",
                            PageOrientation = Orientation.Portrait,
                            PageSize = Size.A4
                        };
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

        // view all rejected orders
        [HttpGet]
        public IActionResult ViewRejectedOrders()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    ViewBag.RejectedOrders = orderManager.GetRejectedOrderedItems();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view all ordered items
        [HttpGet]
        public IActionResult ViewAllOrders()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    ViewBag.Orders = orderManager.GetOrderedItems();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // remove order
        [HttpGet]
        public IActionResult RemoveOrder(int infoId)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    OrderInfo orderInfo = orderManager.GetOrderInfoByInfoId(infoId);

                    if (orderInfo != null)
                    {
                        orderInfo.State = 0;
                        orderInfo.IsClientState = 0;

                        List<Order> orders = new List<Order>();
                        foreach (Order order in orderInfo.Orders)
                        {
                            order.State = 0;
                            order.IsClientState = 0;
                            orders.Add(order);
                        }

                        orderInfo.Orders = orders;

                        orderManager.RemoveOrder(orderInfo);

                        return RedirectToAction("ViewAllOrders", "OrderItem");
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

        // report
        public IActionResult Reporting(int month, int year)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    ReportingViewModel model = orderManager.GetReportDetailsByMonthOrYear(month, year);

                    if (model != null)
                    {
                        model.Month = month;
                        model.Year = year;
                        return new ViewAsPdf("Reporting", model);
                    }
                    else
                    {
                        return NotFound("Not Data Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view sell report
        [HttpGet]
        public IActionResult ViewSellReport()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    ViewBag.Years = orderManager.GetYearsForDropDown();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        [HttpPost]
        public IActionResult ViewSellReport(int month, int year)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 5))
                {
                    if (month == 0 || year == 0)
                    {
                        ViewData["Message"] = BootstrapMessages.Failed("Please select month or year");

                        ViewBag.Years = orderManager.GetYearsForDropDown();
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Reporting", "OrderItem", new {month = month, year = year});
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