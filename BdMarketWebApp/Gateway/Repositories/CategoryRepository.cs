using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.Context;

namespace BdMarketWebApp.Gateway.Repositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext _context):base(_context)
        {
            this.context = _context;
        }

        public int Rows()
        {
            return context.Categories.Where(x => x.State == 1).ToList().Count;
        }
    }
}
