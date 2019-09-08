using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Utility;

namespace BdMarketWebApp.Manager
{
    public class DeliveryManager
    {
        private UnitOfWork unitOfWork;

        public DeliveryManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // save delivery
        public string Save(Delivery delivery)
        {
            if (unitOfWork.Delivery.IsExists(x => x.PlaceName == delivery.PlaceName && x.State == 1))
            {
                return BootstrapMessages.Failed("Place Name already exists");
            }
            else
            {
                unitOfWork.Delivery.Add(delivery);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return BootstrapMessages.Success("Delivery Info Successfully Saved");
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Save delivery info");
                }
            }
        }

        //view all delivery
        public List<Delivery> ViewAllDeliveries()
        {
            return unitOfWork.Delivery.GetAllByExpression(x => x.State == 1).ToList();
        }

        //update
        public string Update(Delivery delivery)
        {
            if (unitOfWork.Delivery.IsExists(x =>
                x.PlaceName == delivery.PlaceName && x.State == 1 && x.Id != delivery.Id))
            {
                return BootstrapMessages.Failed("Place Name already exists");
            }
            else
            {
                unitOfWork.Delivery.Update(delivery);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return "1";
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to update delivery info");
                }
            }
        }

        // get by id
        public Delivery GetById(int id)
        {
            return unitOfWork.Delivery.Get(x => x.Id == id && x.State == 1);
        }

        // is id exists
        public bool IsIdExists(int id)
        {
            return unitOfWork.Delivery.IsExists(x => x.Id == id && x.State == 1);
        }
    }
}
