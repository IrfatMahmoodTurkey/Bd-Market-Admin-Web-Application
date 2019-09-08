using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BdMarketWebApp.Manager
{
    [EnableCors("AllowAll")]
    public class OrderManager
    {
        private UnitOfWork unitOfWork;

        public OrderManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // order items
        public object OrderItems(OrderInfo order)
        {
            if (order.IsHomeDelivery == 1)
            {
                order.DeliveryCharge = GetDeliveryAmount(order.DeliveryId);
            }
            else
            {
                order.DeliveryCharge = 0;
            }

            List<Order> cartItems = new List<Order>();

            foreach (Order value in order.Orders)
            {
                value.Profit = GetProfit(value.ProductId, value.Quantity);
                value.OrderId = Guid.NewGuid().ToString();
                value.OrderDate = DateTime.Now.ToString("F");
                value.OrderMonth = DateTime.Now.Month.ToString();
                value.OrderYear = DateTime.Now.Year.ToString();
                value.IsNew = 1;
                value.IsDelivered = 0;
                value.IsReceived = 0;
                value.LastActionBy = "Client";
                value.ActionTime = DateTime.Now.ToString("F");
                value.ActionDone = "ORDER";
                value.State = 1;
                value.IsClientState = 1;

                cartItems.Add(value);
            }

            order.Orders = cartItems;

            unitOfWork.OrderInfo.Add(order);
            int rowsAffected = unitOfWork.Completed();

            if (rowsAffected > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        // get delivery amount
        public decimal GetDeliveryAmount(int deliveryId)
        {
            return unitOfWork.Delivery.Get(x => x.Id == deliveryId && x.State == 1).Charge;
        }

        // get profit only by product id
        public decimal GetProfit(int productId, int quantity)
        {
            ProductViewModel model = unitOfWork.Product.ViewProduct(productId);

            return model.Profit * quantity;
        }

        // get IsNew ordered products
        public List<OrderInfoViewModel> GetNewOrderedProducts()
        {
            return unitOfWork.OrderInfo.GetNewItems();
        }

        // get order by id for make order received
        public Order GetByIdForOrder(int id)
        {
            Order order = unitOfWork.Order.Get(x => x.Id == id && x.State == 1);
            return order;
        }

        // update order items
        public int Update(Order order)
        {
            unitOfWork.Order.Update(order);
            int rowsAffected = unitOfWork.Completed();

            if (rowsAffected > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // get delivered items
        public List<OrderInfoViewModel> GetDeliveredItems()
        {
            return unitOfWork.OrderInfo.GetDeliveredOrderInfo();
        }

        // get order details by info id
        public OrderInfoViewModel GetOrderDetailsByInfoId(int infoId)
        {
            return unitOfWork.OrderInfo.GetOrderById(infoId);
        }

        // get rejected order items
        public List<OrderInfoViewModel> GetRejectedOrderedItems()
        {
            return unitOfWork.OrderInfo.GetRejectedOrderInfo();
        }

        // get all ordered items
        public List<OrderInfoViewModel> GetOrderedItems()
        {
            return unitOfWork.OrderInfo.GetAllOrderInfo();
        }

        // get order info by id
        public OrderInfo GetOrderInfoById(int id)
        {
            return unitOfWork.OrderInfo.Get(x => x.Id == id && x.State == 1);
        }

        // get orderinfo by info id
        public OrderInfo GetOrderInfoByInfoId(int infoId)
        {
            return unitOfWork.OrderInfo.GetInfoByInfoId(infoId);
        }

        // remove order
        public int RemoveOrder(OrderInfo orderInfo)
        {
            unitOfWork.OrderInfo.Update(orderInfo);
            int rowsAffected = unitOfWork.Completed();

            if (rowsAffected > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // get orders for client side by action Id
        public List<OrderInfoViewModel> GetOrdersForClientSide(int actionId)
        {
            return unitOfWork.OrderInfo.GetAllOrderInfoByActionIdForClient(actionId);
        }

        // get order items by month and year
        public ReportingViewModel GetReportDetailsByMonthOrYear(int month, int year)
        {
            List<OrderItemViewModel> models = unitOfWork.OrderInfo.GetOrderItemByMonthAndYear(month, year);

            ReportingViewModel model = new ReportingViewModel();

            if (models.Count > 0)
            {
                model.Total = models.Where(x=>x.IsReceived == 1 && x.IsDelivered == 1 && x.IsNew == 0 && x.State == 1).Sum(x => x.ProductPrice);
                model.Profit = models.Where(x => x.IsReceived == 1 && x.IsDelivered == 1 && x.IsNew == 0 && x.State == 1).Sum(x => x.Profit);
                model.Quantity = models.Where(x => x.IsReceived == 1 && x.IsDelivered == 1 && x.IsNew == 0 && x.State == 1).Sum(x => x.Quantity);

                model.OrderItemViewModels = models;

                return model;
            }
            else
            {
                return null;
            }
        }

        // order year for dropdown
        public List<SelectListItem> GetYearsForDropDown()
        {
            List<string> years = unitOfWork.OrderInfo.GetAllOrderYears();

            List<SelectListItem> selectListItems = years.ConvertAll(x => new SelectListItem()
                {Text = x.ToString(), Value = x.ToString()});
            
            return selectListItems;
        }
    }
}
