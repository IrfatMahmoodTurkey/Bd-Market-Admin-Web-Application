using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;

namespace BdMarketWebApp.Gateway.IRepositories
{
    public interface IOrderRepository:IRepository<OrderInfo>
    {
        int Rows();
        List<OrderInfoViewModel> GetNewItems();
        List<OrderItemViewModel> GetNewOrders(int infoId);
        List<OrderInfoViewModel> GetDeliveredOrderInfo();
        List<OrderItemViewModel> GetDeliveredOrders(int infoId);
        OrderInfoViewModel GetOrderById(int infoId);
        List<OrderInfoViewModel> GetRejectedOrderInfo();
        List<OrderItemViewModel> GetRejectedOrders(int infoId);
        List<OrderInfoViewModel> GetAllOrderInfo();
        List<OrderItemViewModel> GetAllOrders(int infoId);
        OrderInfo GetInfoByInfoId(int infoId);
        List<OrderInfoViewModel> GetAllOrderInfoByActionIdForClient(int actionId);
        List<OrderItemViewModel> GetAllOrderForClient(int infoId);
        List<OrderItemViewModel> GetOrderItemByMonthAndYear(int month, int year);
        List<string> GetAllOrderYears();
        int NumberOfNewOrders();
        decimal SoldAmountByMonth(int month, int year);
        decimal SoldProfitByMonth(int month, int year);
        decimal SoldAmountByYear(int year);
        decimal SoldProfitByYear(int year);
    }
}
