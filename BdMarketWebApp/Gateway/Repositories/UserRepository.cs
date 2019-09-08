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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext context;
        public UserRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }

        public int Rows()
        {
            return context.Users.Where(x => x.State == 1).ToList().Count;
        }
    }
}
