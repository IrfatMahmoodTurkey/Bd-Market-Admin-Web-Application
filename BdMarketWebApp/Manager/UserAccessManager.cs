using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Utility;

namespace BdMarketWebApp.Manager
{
    public class UserAccessManager
    {
        private UnitOfWork unitOfWork;

        public UserAccessManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // save user access
        public string SaveUserAccess(UserAccess userAccess)
        {
            if (unitOfWork.UserAccess.IsExists(x =>
                x.UserId == userAccess.UserId && x.PageId == userAccess.PageId && x.State == 1))
            {
                return BootstrapMessages.Failed("Access already given");
            }
            else
            {
                unitOfWork.UserAccess.Add(userAccess);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return "1";
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to give access");
                }
            }
        }

        // view all access by user id
        public List<UserAccess> GetAccessByUserId(int userId)
        {
            return unitOfWork.UserAccess.GetAllByExpression(x => x.UserId == userId && x.State == 1).ToList();
        }

        // remove access
        public int Update(UserAccess userAccess)
        {
            unitOfWork.UserAccess.Update(userAccess);
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

        // get by id
        public UserAccess GetById(int id)
        {
            return unitOfWork.UserAccess.Get(x => x.Id == id && x.State == 1);
        }

        // check access exists
        public bool IsAccessExists(int userId, int pageId)
        {
            return unitOfWork.UserAccess.IsExists(x => x.UserId == userId && x.PageId == pageId && x.State == 1);
        }

        // if id is exits
        public bool IsIdExists(int id)
        {
            return unitOfWork.UserAccess.IsExists(x => x.Id == id && x.State == 1);
        }
    }
}
