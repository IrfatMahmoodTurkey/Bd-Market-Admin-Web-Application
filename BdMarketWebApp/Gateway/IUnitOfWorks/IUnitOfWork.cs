using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;

namespace BdMarketWebApp.Gateway.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; set; }
        IProductRepository Product { get; set; }
        IDesignationRepository Designation { get; set; }
        IEmployeeRepository Employee { get; set; }
        IUserRepository User { get; set; }
        IOrderRepository OrderInfo { get; set; }
        IOrderItemsRepository Order { get; set; }
        IDeliveryRepository Delivery { get; set; }
        IUserAccessRepository UserAccess { get; set; }
    }
}
