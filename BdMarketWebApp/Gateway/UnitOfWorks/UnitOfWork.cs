using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;
using BdMarketWebApp.Gateway.IUnitOfWorks;
using BdMarketWebApp.Gateway.Repositories;
using BdMarketWebApp.Models.Context;

namespace BdMarketWebApp.Gateway.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        public ICategoryRepository Category { get; set; }
        public IProductRepository Product { get; set; }
        public IDesignationRepository Designation { get; set; }
        public IEmployeeRepository Employee { get; set; }
        public IUserRepository User { get; set; }
        public IOrderRepository OrderInfo { get; set; }
        public IOrderItemsRepository Order { get; set; }
        public IDeliveryRepository Delivery { get; set; }
        public IUserAccessRepository UserAccess { get; set; }


        ApplicationDbContext context = new ApplicationDbContext();

        public UnitOfWork()
        {
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Designation = new DesignationRepository(context);
            Employee = new EmployeeRepository(context);
            User = new UserRepository(context);
            OrderInfo = new OrderRepository(context);
            Order = new OrderItemRepository(context);
            Delivery = new DeliveryRepository(context);
            UserAccess = new UserAccessRepository(context);
        }

        public int Completed()
        {
            int rowsAffeced = context.SaveChanges();
            return rowsAffeced;
        }
    }
}
