using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;

namespace BdMarketWebApp.Manager
{
    public class DashboardManager
    {
        private UnitOfWork unitOfWork;

        public DashboardManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // get total item
        public int ItemsCount()
        {
            return unitOfWork.Product.RowCount();
        }

        // get stock out items count
        public int StockOutItemCount()
        {
            return unitOfWork.Product.NumberOfStockOutRangeItems();
        }

        // get new orders count
        public int NewOrdersCount()
        {
            return unitOfWork.OrderInfo.NumberOfNewOrders();
        }

        // number of users
        public int NumberOfUsers()
        {
            return unitOfWork.User.Rows();
        }

        // get yearly sold amount by all month
        public List<decimal> YearlySoldAmount()
        {
            int year = DateTime.Now.Year;
            List<decimal> amounts = new List<decimal>();

            for (int i = 1; i < 13; i++)
            {
                decimal amount = unitOfWork.OrderInfo.SoldAmountByMonth(i, year);
                amounts.Add(amount);
            }

            return amounts;
        }

        // get yearly sold profit by all month
        public List<decimal> YearlyProfit()
        {
            int year = DateTime.Now.Year;
            List<decimal> profits = new List<decimal>();

            for (int i = 1; i < 13; i++)
            {
                decimal profit = unitOfWork.OrderInfo.SoldProfitByMonth(i, year);
                profits.Add(profit);
            }

            return profits;
        }

        // get sold amount by only year
        public List<decimal> SoldAmountHistory()
        {
            int year = DateTime.Now.Year;
            List<decimal> amounts = new List<decimal>();

            for (int i = 1; i < 5; i++)
            {
                decimal amount = unitOfWork.OrderInfo.SoldAmountByYear(year);
                year = year - 1;

                amounts.Add(amount);
            }

            return amounts;
        }

        // get profit by only year
        public List<decimal> SoldProfitHistory()
        {
            int year = DateTime.Now.Year;
            List<decimal> profits = new List<decimal>();

            for (int i = 1; i < 5; i++)
            {
                decimal profit = unitOfWork.OrderInfo.SoldAmountByYear(year);
                year = year - 1;

                profits.Add(profit);
            }

            return profits;
        }

        // return this year with last four year
        public List<int> GetYears()
        {
            int year = DateTime.Now.Year;

            List<int> years = new List<int>();

            for (int i = 1; i < 5; i++)
            {
                years.Add(year);
                year--;
            }

            return years;
        }
    }
}
