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
    public class OrderRepository:Repository<OrderInfo>, IOrderRepository
    {
        private ApplicationDbContext context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public int Rows()
        {
            throw new NotImplementedException();
        }

        public List<OrderInfoViewModel> GetNewItems()
        {
            var query = context.OrderInfo.Include(x=>x.Delivery).Include(x=>x.User).Where(x=>x.State == 1);

            List<OrderInfoViewModel> viewModels = new List<OrderInfoViewModel>();

            foreach (var data in query)
            {
                OrderInfoViewModel viewModel = new OrderInfoViewModel();

                viewModel.InfoId = data.Id;
                viewModel.FirstName = data.FirstName;
                viewModel.LastName = data.LastName;
                viewModel.Email = data.Email;
                viewModel.Phone = data.Phone;
                viewModel.AddressOne = data.AddressOne;
                viewModel.AddressTwo = data.AddressTwo;
                viewModel.DeliveryId = data.Delivery.Id;
                viewModel.DeliveryPlace = data.Delivery.PlaceName;
                viewModel.IsHomeDelivery = data.IsHomeDelivery;
                viewModel.DeliveryCharge = data.DeliveryCharge;
                viewModel.ActionByUserEmail = data.User.Email;
                viewModel.State = data.State;
                viewModel.OrderItemViewModels = GetNewOrders(data.Id);

                if (viewModel.OrderItemViewModels.Count > 0)
                {
                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        public List<OrderItemViewModel> GetNewOrders(int infoId)
        {
            var query = context.Orders.Include(x=>x.Product).Include(x => x.Category).Where(i => i.IsNew == 1 && i.InfoId == infoId && i.State == 1);
            List<OrderItemViewModel> items = new List<OrderItemViewModel>();

            foreach (var item in query)
            {
                OrderItemViewModel itemViewModel = new OrderItemViewModel();

                itemViewModel.OrderItemId = item.Id;
                itemViewModel.ProductName = item.Product.ProductTitle;
                itemViewModel.ProductId = item.ProductId;
                itemViewModel.CategoryName = item.Category.Name;
                itemViewModel.CategoryId = item.CategoryId;
                itemViewModel.Quantity = item.Quantity;
                itemViewModel.OrderId = item.OrderId;
                itemViewModel.ProductPrice = item.ProductPrice;
                itemViewModel.OrderDate = item.OrderDate;
                itemViewModel.IsReceived = item.IsReceived;
                itemViewModel.IsDelivered = item.IsDelivered;
                itemViewModel.IsNew = item.IsNew;
                itemViewModel.LastActionBy = item.LastActionBy;
                itemViewModel.ActionTime = item.ActionTime;
                itemViewModel.ActionDone = item.ActionDone;

                items.Add(itemViewModel);
            }

            return items;
        }

        // get delivered items with info
        public List<OrderInfoViewModel> GetDeliveredOrderInfo()
        {
            var query = context.OrderInfo.Include(x => x.Delivery).Include(x => x.User).Where(x => x.State == 1);

            List<OrderInfoViewModel> viewModels = new List<OrderInfoViewModel>();

            foreach (var data in query)
            {
                OrderInfoViewModel viewModel = new OrderInfoViewModel();

                viewModel.InfoId = data.Id;
                viewModel.FirstName = data.FirstName;
                viewModel.LastName = data.LastName;
                viewModel.Email = data.Email;
                viewModel.Phone = data.Phone;
                viewModel.AddressOne = data.AddressOne;
                viewModel.AddressTwo = data.AddressTwo;
                viewModel.DeliveryId = data.Delivery.Id;
                viewModel.DeliveryPlace = data.Delivery.PlaceName;
                viewModel.IsHomeDelivery = data.IsHomeDelivery;
                viewModel.DeliveryCharge = data.DeliveryCharge;
                viewModel.ActionByUserEmail = data.User.Email;
                viewModel.State = data.State;
                viewModel.OrderItemViewModels = GetDeliveredOrders(data.Id);

                if (viewModel.OrderItemViewModels.Count > 0)
                {
                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        public List<OrderItemViewModel> GetDeliveredOrders(int infoId)
        {
            var query = context.Orders.Include(x => x.Product).Include(x => x.Category).Where(i => i.IsNew == 0 && i.InfoId == infoId && i.IsReceived == 1 && i.IsDelivered == 1 && i.State == 1);
            List<OrderItemViewModel> items = new List<OrderItemViewModel>();

            foreach (var item in query)
            {
                OrderItemViewModel itemViewModel = new OrderItemViewModel();

                itemViewModel.OrderItemId = item.Id;
                itemViewModel.ProductName = item.Product.ProductTitle;
                itemViewModel.ProductId = item.ProductId;
                itemViewModel.CategoryName = item.Category.Name;
                itemViewModel.CategoryId = item.CategoryId;
                itemViewModel.Quantity = item.Quantity;
                itemViewModel.OrderId = item.OrderId;
                itemViewModel.ProductPrice = item.ProductPrice;
                itemViewModel.OrderDate = item.OrderDate;
                itemViewModel.IsReceived = item.IsReceived;
                itemViewModel.IsDelivered = item.IsDelivered;
                itemViewModel.IsNew = item.IsNew;
                itemViewModel.LastActionBy = item.LastActionBy;
                itemViewModel.ActionTime = item.ActionTime;
                itemViewModel.ActionDone = item.ActionDone;

                items.Add(itemViewModel);
            }

            return items;
        }

        public OrderInfoViewModel GetOrderById(int infoId)
        {
            var query = context.OrderInfo.Include(x => x.Delivery).Include(x => x.User).Where(x => x.State == 1 && x.Id == infoId).FirstOrDefault();

            OrderInfoViewModel viewModel = new OrderInfoViewModel();

            viewModel.InfoId = query.Id;
            viewModel.FirstName = query.FirstName;
            viewModel.LastName = query.LastName;
            viewModel.Email = query.Email;
            viewModel.Phone = query.Phone;
            viewModel.ActionByUserName = query.User.UserName;
            viewModel.ActionByUserEmail = query.User.Email;
            viewModel.ActionTime = query.ActionTime;
            viewModel.AddressOne = query.AddressOne;
            viewModel.AddressTwo = query.AddressTwo;
            viewModel.DeliveryId = query.Delivery.Id;
            viewModel.DeliveryPlace = query.Delivery.PlaceName;
            viewModel.IsHomeDelivery = query.IsHomeDelivery;
            viewModel.DeliveryCharge = query.DeliveryCharge;
            viewModel.State = query.State;
            viewModel.OrderItemViewModels = GetDeliveredOrders(query.Id);


            return viewModel;
        }

        public List<OrderInfoViewModel> GetRejectedOrderInfo()
        {
            var query = context.OrderInfo.Include(x => x.Delivery).Include(x => x.User).Where(x => x.State == 1);

            List<OrderInfoViewModel> viewModels = new List<OrderInfoViewModel>();

            foreach (var data in query)
            {
                OrderInfoViewModel viewModel = new OrderInfoViewModel();

                viewModel.InfoId = data.Id;
                viewModel.FirstName = data.FirstName;
                viewModel.LastName = data.LastName;
                viewModel.Email = data.Email;
                viewModel.Phone = data.Phone;
                viewModel.AddressOne = data.AddressOne;
                viewModel.AddressTwo = data.AddressTwo;
                viewModel.DeliveryId = data.Delivery.Id;
                viewModel.DeliveryPlace = data.Delivery.PlaceName;
                viewModel.IsHomeDelivery = data.IsHomeDelivery;
                viewModel.DeliveryCharge = data.DeliveryCharge;
                viewModel.ActionByUserEmail = data.User.Email;
                viewModel.State = data.State;
                viewModel.OrderItemViewModels = GetRejectedOrders(data.Id);

                if (viewModel.OrderItemViewModels.Count > 0)
                {
                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        public List<OrderItemViewModel> GetRejectedOrders(int infoId)
        {
            var query = context.Orders.Include(x => x.Product).Include(x => x.Category).Where(i => i.IsNew == 0 && i.InfoId == infoId && (i.IsReceived == 0 || i.IsReceived == 1) && i.IsDelivered == 0 && i.State == 1);
            List<OrderItemViewModel> items = new List<OrderItemViewModel>();

            foreach (var item in query)
            {
                OrderItemViewModel itemViewModel = new OrderItemViewModel();

                itemViewModel.OrderItemId = item.Id;
                itemViewModel.ProductName = item.Product.ProductTitle;
                itemViewModel.ProductId = item.ProductId;
                itemViewModel.CategoryName = item.Category.Name;
                itemViewModel.CategoryId = item.CategoryId;
                itemViewModel.Quantity = item.Quantity;
                itemViewModel.OrderId = item.OrderId;
                itemViewModel.ProductPrice = item.ProductPrice;
                itemViewModel.OrderDate = item.OrderDate;
                itemViewModel.IsReceived = item.IsReceived;
                itemViewModel.IsDelivered = item.IsDelivered;
                itemViewModel.IsNew = item.IsNew;
                itemViewModel.LastActionBy = item.LastActionBy;
                itemViewModel.ActionTime = item.ActionTime;
                itemViewModel.ActionDone = item.ActionDone;

                items.Add(itemViewModel);
            }

            return items;
        }

        public List<OrderInfoViewModel> GetAllOrderInfo()
        {
            var query = context.OrderInfo.Include(x => x.Delivery).Include(x => x.User).Where(x => x.State == 1);

            List<OrderInfoViewModel> viewModels = new List<OrderInfoViewModel>();

            foreach (var data in query)
            {
                OrderInfoViewModel viewModel = new OrderInfoViewModel();

                viewModel.InfoId = data.Id;
                viewModel.FirstName = data.FirstName;
                viewModel.LastName = data.LastName;
                viewModel.Email = data.Email;
                viewModel.Phone = data.Phone;
                viewModel.ActionByUserName = data.User.UserName;
                viewModel.ActionByUserEmail = data.User.Email;
                viewModel.AddressOne = data.AddressOne;
                viewModel.AddressTwo = data.AddressTwo;
                viewModel.DeliveryId = data.Delivery.Id;
                viewModel.DeliveryPlace = data.Delivery.PlaceName;
                viewModel.IsHomeDelivery = data.IsHomeDelivery;
                viewModel.DeliveryCharge = data.DeliveryCharge;
                viewModel.ActionTime = data.ActionTime;
                viewModel.State = data.State;
                viewModel.OrderItemViewModels = GetAllOrders(data.Id);

                if (viewModel.OrderItemViewModels.Count > 0)
                {
                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        public List<OrderItemViewModel> GetAllOrders(int infoId)
        {
            var query = context.Orders.Include(x => x.Product).Include(x => x.Category).Where(i => i.InfoId == infoId && i.State == 1);
            List<OrderItemViewModel> items = new List<OrderItemViewModel>();

            foreach (var item in query)
            {
                OrderItemViewModel itemViewModel = new OrderItemViewModel();

                itemViewModel.OrderItemId = item.Id;
                itemViewModel.ProductName = item.Product.ProductTitle;
                itemViewModel.ProductId = item.ProductId;
                itemViewModel.CategoryName = item.Category.Name;
                itemViewModel.CategoryId = item.CategoryId;
                itemViewModel.Quantity = item.Quantity;
                itemViewModel.OrderId = item.OrderId;
                itemViewModel.ProductPrice = item.ProductPrice;
                itemViewModel.OrderDate = item.OrderDate;
                itemViewModel.IsReceived = item.IsReceived;
                itemViewModel.IsDelivered = item.IsDelivered;
                itemViewModel.IsNew = item.IsNew;
                itemViewModel.LastActionBy = item.LastActionBy;
                itemViewModel.ActionTime = item.ActionTime;
                itemViewModel.ActionDone = item.ActionDone;

                items.Add(itemViewModel);
            }

            return items;
        }

        public OrderInfo GetInfoByInfoId(int infoId)
        {
            OrderInfo orderInfo = context.OrderInfo.Include(x => x.Orders).Where(x => x.Id == infoId && x.State == 1).FirstOrDefault();
            return orderInfo;
        }

        public List<OrderInfoViewModel> GetAllOrderInfoByActionIdForClient(int actionId)
        {
            var query = context.OrderInfo.Include(x => x.Delivery).Include(x => x.User).Where(x => x.State == 1 && x.ActionById == actionId && x.IsClientState == 1).OrderByDescending(x=>x.Id);

            List<OrderInfoViewModel> viewModels = new List<OrderInfoViewModel>();

            foreach (var data in query)
            {
                OrderInfoViewModel viewModel = new OrderInfoViewModel();

                viewModel.InfoId = data.Id;
                viewModel.FirstName = data.FirstName;
                viewModel.LastName = data.LastName;
                viewModel.Email = data.Email;
                viewModel.Phone = data.Phone;
                viewModel.ActionByUserName = data.User.UserName;
                viewModel.ActionByUserEmail = data.User.Email;
                viewModel.AddressOne = data.AddressOne;
                viewModel.AddressTwo = data.AddressTwo;
                viewModel.DeliveryId = data.Delivery.Id;
                viewModel.DeliveryPlace = data.Delivery.PlaceName;
                viewModel.IsHomeDelivery = data.IsHomeDelivery;
                viewModel.DeliveryCharge = data.DeliveryCharge;
                viewModel.ActionTime = data.ActionTime;
                viewModel.OrderItemViewModels = GetAllOrderForClient(data.Id);

                if (viewModel.OrderItemViewModels.Count > 0)
                {
                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        public List<OrderItemViewModel> GetAllOrderForClient(int infoId)
        {
            var query = context.Orders.Include(x => x.Product).Include(x => x.Category).Where(i => i.InfoId == infoId && i.State == 1 && i.IsClientState == 1);
            List<OrderItemViewModel> items = new List<OrderItemViewModel>();

            foreach (var item in query)
            {
                OrderItemViewModel itemViewModel = new OrderItemViewModel();

                itemViewModel.OrderItemId = item.Id;
                itemViewModel.ProductName = item.Product.ProductTitle;
                itemViewModel.ProductId = item.ProductId;
                itemViewModel.CategoryName = item.Category.Name;
                itemViewModel.CategoryId = item.CategoryId;
                itemViewModel.Quantity = item.Quantity;
                itemViewModel.OrderId = item.OrderId;
                itemViewModel.ProductPrice = item.ProductPrice;
                itemViewModel.OrderDate = item.OrderDate;

                items.Add(itemViewModel);
            }

            return items;
        }

        public List<OrderItemViewModel> GetOrderItemByMonthAndYear(int month, int year)
        {
            var query = context.Orders.Include(x => x.Product).Include(x => x.Category).Where(x=>x.State == 1 && x.OrderMonth == month.ToString() && x.OrderYear == year.ToString());
            List<OrderItemViewModel> items = new List<OrderItemViewModel>();

            foreach (var item in query)
            {
                OrderItemViewModel itemViewModel = new OrderItemViewModel();

                itemViewModel.OrderItemId = item.Id;
                itemViewModel.ProductName = item.Product.ProductTitle;
                itemViewModel.ProductId = item.ProductId;
                itemViewModel.CategoryName = item.Category.Name;
                itemViewModel.CategoryId = item.CategoryId;
                itemViewModel.Quantity = item.Quantity;
                itemViewModel.OrderId = item.OrderId;
                itemViewModel.ProductPrice = item.ProductPrice;
                itemViewModel.Profit = item.Profit;
                itemViewModel.OrderDate = item.OrderDate;
                itemViewModel.IsReceived = item.IsReceived;
                itemViewModel.IsDelivered = item.IsDelivered;
                itemViewModel.IsNew = item.IsNew;
                itemViewModel.State = item.State;
                itemViewModel.LastActionBy = item.LastActionBy;
                itemViewModel.ActionTime = item.ActionTime;
                itemViewModel.ActionDone = item.ActionDone;

                items.Add(itemViewModel);
            }

            return items;
        }

        public List<string> GetAllOrderYears()
        {
            List<string> years = new List<string>();

            var query = context.Orders.GroupBy(x => x.OrderYear);

            foreach (var year in query)
            {
                years.Add(year.Key);
            }

            return years;
        }

        public int NumberOfNewOrders()
        {
            return context.Orders.Where(x => x.State == 1 && x.IsNew == 1).ToList().Count;
        }

        public decimal SoldAmountByMonth(int month, int year)
        {
            return context.Orders
                .Where(x => x.State == 1 && x.OrderMonth == month.ToString() && x.OrderYear == year.ToString()).ToList()
                .Sum(x=>x.ProductPrice);
        }

        public decimal SoldProfitByMonth(int month, int year)
        {
            return context.Orders
                .Where(x => x.State == 1 && x.OrderMonth == month.ToString() && x.OrderYear == year.ToString()).ToList()
                .Sum(x => x.Profit);
        }

        public decimal SoldAmountByYear(int year)
        {
            return context.Orders
                .Where(x => x.State == 1 && x.OrderYear == year.ToString()).ToList()
                .Sum(x => x.ProductPrice);
        }

        public decimal SoldProfitByYear(int year)
        {
            return context.Orders
                .Where(x => x.State == 1 && x.OrderYear == year.ToString()).ToList()
                .Sum(x => x.Profit);
        }
    }
}
