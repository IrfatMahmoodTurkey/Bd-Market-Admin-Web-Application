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
    public class OrderController : ControllerBase
    {
        private OrderManager orderManager;
        private DeliveryManager deliveryManager;

        public OrderController()
        {
            orderManager = new OrderManager();
            deliveryManager = new DeliveryManager();
        }

        // order items
        [Route("OrderItem")]
        [HttpPost]
        public object Order()
        {
            OrderInfo order = new OrderInfo();

            order.FirstName = Request.Form["FirstName"];
            order.LastName = Request.Form["LastName"];
            order.Email = Request.Form["Email"];
            order.Phone = Request.Form["Phone"];
            order.AddressOne = Request.Form["AddressOne"];
            order.AddressTwo = Request.Form["AddressTwo"];
            order.ActionById = Convert.ToInt32(Request.Form["User_Id"]);
            order.DeliveryId = Convert.ToInt32(Request.Form["DeliveryPlace"]);
            order.IsHomeDelivery = Convert.ToInt32(Request.Form["IsHomeDelivery"]);
            order.ActionTime = Request.Form["ActionDate"];
            order.State = 1;
            order.IsClientState = 1;
            order.Orders = JsonConvert.DeserializeObject<List<Order>>(Request.Form["Cart"]);
            
            return orderManager.OrderItems(order);
        }

        // view orders
        [Route("ViewOrders")]
        [HttpGet]
        public object ViewAllOrders(int clientId)
        {
            List<OrderInfoViewModel> orderInfo = orderManager.GetOrdersForClientSide(clientId);
            return orderInfo;
        }

        // remove order from client side
        [Route("RemoveItem")]
        [HttpGet]
        public object RemoveItemForClient(int orderId)
        {
            Order order = orderManager.GetByIdForOrder(orderId);

            if (order != null)
            {
                order.IsClientState = 0;

                int message = orderManager.Update(order);

                if (message == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "3";
            }
        }

        // remove order
        [Route("RemoveFullOrder")]
        [HttpGet]
        public object RemoveOrder(int infoId)
        {
            OrderInfo orderInfo = orderManager.GetOrderInfoByInfoId(infoId);

            if (orderInfo != null)
            {
                orderInfo.IsClientState = 0;

                List<Order> orders = new List<Order>();
                foreach (Order order in orderInfo.Orders)
                {
                    order.IsClientState = 0;
                    orders.Add(order);
                }

                orderInfo.Orders = orders;

                int message = orderManager.RemoveOrder(orderInfo);

                if (message == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "3";
            }
        }

        [Route("GetAllDeliveryPlaces")]
        [HttpGet]
        public object GetAllDeliveryDetalis()
        {
            List<Delivery> deliveries = deliveryManager.ViewAllDeliveries();
            return deliveries;
        }
    }
}