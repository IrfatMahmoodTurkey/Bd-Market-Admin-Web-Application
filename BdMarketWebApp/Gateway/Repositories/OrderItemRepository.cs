using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BdMarketWebApp.Gateway.Repositories
{
    public class OrderItemRepository:Repository<Order>, IOrderItemsRepository
    {
        private ApplicationDbContext context;
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public int Rows()
        {
            throw new NotImplementedException();
        }
    }
}
