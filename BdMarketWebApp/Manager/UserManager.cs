using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;

namespace BdMarketWebApp.Manager
{
    public class UserManager
    {
        private UnitOfWork unitOfWork;

        public UserManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // register employee
        public string RegisterUser(User user)
        {
            if (unitOfWork.User.IsExists(x => x.Email == user.Email && x.State == 1))
            {
                return "2";
            }
            else
            {
                unitOfWork.User.Add(user);
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
        }

        // get user by email
        public User GetUserByEmail(string email)
        {
            return unitOfWork.User.Get(x => x.Email == email && x.State == 1);
        }

        // verify account
        public string VerifyAccount(VerifyAccountViewModel model)
        {
            User user = GetUserByEmail(model.Email);

            if (user != null)
            {
                if (user.VerificationCode.Equals(model.VerificationCode))
                {
                    user.Verify = 1;
                    unitOfWork.User.Update(user);
                    int rowsAffected = unitOfWork.Completed();

                    if (rowsAffected > 0)
                    {
                        // verified
                        return "1";
                    }
                    else
                    {
                        // failed
                        return "0";
                    }
                }
                else
                {
                    // invalid verfication code
                    return "2";
                }
            }
            else
            {
                // invalid user
                return "3";
            }
        }

        // log in by verification code
        public User LogInByVerificationCode(string email, string code)
        {
            User user = unitOfWork.User.Get(x =>
                x.Email == email && x.VerificationCode == code && x.Verify == 1 &&
                x.State == 1);

            return user;
        }

        // normal log in
        public User LogIn(UserLoginViewModel login)
        {
            User user = unitOfWork.User.Get(x =>
                x.Email == login.Email && x.Password == login.Password && x.State == 1);

            return user;
        }

        // is 

        // update user info
        public string Update(User user)
        {
            unitOfWork.User.Update(user);
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

        // get all users
        public List<User> GetAllUsers()
        {
            return unitOfWork.User.GetAllByExpression(x => x.State == 1).ToList();
        }

        // get user by id
        public User GetUserById(int id)
        {
            return unitOfWork.User.Get(x => x.UserId == id && x.State == 1);
        }

        // id is exists
        public bool IsIdExists(int id)
        {
            return unitOfWork.User.IsExists(x => x.UserId == id && x.State == 1);
        }
    }
}
