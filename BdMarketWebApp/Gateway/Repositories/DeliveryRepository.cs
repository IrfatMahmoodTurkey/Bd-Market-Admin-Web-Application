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
    public class DeliveryRepository:Repository<Delivery>, IDeliveryRepository
    {
        private ApplicationDbContext context;
        public DeliveryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public int RowCount()
        {
            throw new NotImplementedException();
        }
    }
}
