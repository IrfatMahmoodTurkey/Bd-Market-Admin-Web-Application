using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.Context;
using BdMarketWebApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BdMarketWebApp.Gateway.Repositories
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        private ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }

        public int RowCount()
        {
            return context.Products.Where(x => x.State == 1).ToList().Count;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var query = context.Products.Include(x => x.Category).Where(x=>x.State == 1).ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var data in query)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.Id = data.Id;
                productViewModel.ProductTitle = data.ProductTitle;
                productViewModel.ProductDescription = data.ProductDescription;
                productViewModel.CategoryName = data.Category.Name;
                productViewModel.EntryDate = data.EntryDate;
                productViewModel.EntryMonth = data.EntryMonth;
                productViewModel.EntryYear = data.EntryYear;
                productViewModel.BasePrice = data.BasePrice;
                productViewModel.SellPrice = data.SellPrice;
                productViewModel.Profit = data.Profit;
                productViewModel.ActionBy = data.ActionBy;
                productViewModel.ActionDone = data.ActionDone;
                productViewModel.ActionTime = data.ActionTime;
                productViewModel.Quantity = data.Quantity;
                productViewModel.PictureUrl = data.PictureUrl;

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public ProductViewModel ViewProduct(int id)
        {
            var query = context.Products.Include(x => x.Category).Where(x => x.Id == id && x.State == 1)
                .FirstOrDefault();

            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Id = query.Id;
            productViewModel.ProductTitle = query.ProductTitle;
            productViewModel.ProductDescription = query.ProductDescription;
            productViewModel.CategoryId = query.Category.Id;
            productViewModel.CategoryName = query.Category.Name;
            productViewModel.EntryDate = query.EntryDate;
            productViewModel.EntryMonth = query.EntryMonth;
            productViewModel.EntryYear = query.EntryYear;
            productViewModel.BasePrice = query.BasePrice;
            productViewModel.SellPrice = query.SellPrice;
            productViewModel.Profit = query.Profit;
            productViewModel.ActionBy = query.ActionBy;
            productViewModel.ActionDone = query.ActionDone;
            productViewModel.ActionTime = query.ActionTime;
            productViewModel.Quantity = query.Quantity;
            productViewModel.PictureUrl = query.PictureUrl;

            return productViewModel;
        }

        public List<ProductViewModel> TopItems(int item)
        {
            var query = context.Products.Include(x => x.Category).Where(x => x.State == 1).Take(item).OrderByDescending(x=>x.Id).ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var data in query)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.Id = data.Id;
                productViewModel.ProductTitle = data.ProductTitle;
                productViewModel.ProductDescription = data.ProductDescription;
                productViewModel.CategoryId = data.Category.Id;
                productViewModel.CategoryName = data.Category.Name;
                productViewModel.EntryDate = data.EntryDate;
                productViewModel.EntryMonth = data.EntryMonth;
                productViewModel.EntryYear = data.EntryYear;
                productViewModel.BasePrice = data.BasePrice;
                productViewModel.SellPrice = data.SellPrice;
                productViewModel.Profit = data.Profit;
                productViewModel.ActionBy = data.ActionBy;
                productViewModel.ActionDone = data.ActionDone;
                productViewModel.ActionTime = data.ActionTime;
                productViewModel.Quantity = data.Quantity;
                productViewModel.PictureUrl = data.PictureUrl;

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public List<ProductViewModel> GetRelatedProductByCategory(int categoryId, int num)
        {
            var query = context.Products.Include(x => x.Category).Where(x => x.State == 1 && x.CategoryId == categoryId).Take(num).ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var data in query)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.Id = data.Id;
                productViewModel.ProductTitle = data.ProductTitle;
                productViewModel.ProductDescription = data.ProductDescription;
                productViewModel.CategoryId = data.Category.Id;
                productViewModel.CategoryName = data.Category.Name;
                productViewModel.EntryDate = data.EntryDate;
                productViewModel.EntryMonth = data.EntryMonth;
                productViewModel.EntryYear = data.EntryYear;
                productViewModel.BasePrice = data.BasePrice;
                productViewModel.SellPrice = data.SellPrice;
                productViewModel.Profit = data.Profit;
                productViewModel.ActionBy = data.ActionBy;
                productViewModel.ActionDone = data.ActionDone;
                productViewModel.ActionTime = data.ActionTime;
                productViewModel.Quantity = data.Quantity;
                productViewModel.PictureUrl = data.PictureUrl;

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public int RowCountForRelatedItems(int categoryId)
        {
            return context.Products.Where(x => x.State == 1 && x.CategoryId == categoryId).ToList().Count;
        }

        public List<ProductViewModel> GetItemsByCategoryId(int categoryId)
        {
            var query = context.Products.Include(x => x.Category).Where(x => x.State == 1 && x.CategoryId == categoryId).ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var data in query)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.Id = data.Id;
                productViewModel.ProductTitle = data.ProductTitle;
                productViewModel.ProductDescription = data.ProductDescription;
                productViewModel.CategoryId = data.Category.Id;
                productViewModel.CategoryName = data.Category.Name;
                productViewModel.EntryDate = data.EntryDate;
                productViewModel.EntryMonth = data.EntryMonth;
                productViewModel.EntryYear = data.EntryYear;
                productViewModel.BasePrice = data.BasePrice;
                productViewModel.SellPrice = data.SellPrice;
                productViewModel.Profit = data.Profit;
                productViewModel.ActionBy = data.ActionBy;
                productViewModel.ActionDone = data.ActionDone;
                productViewModel.ActionTime = data.ActionTime;
                productViewModel.Quantity = data.Quantity;
                productViewModel.PictureUrl = data.PictureUrl;

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public List<ProductViewModel> SearchItem(string search)
        {
            var query = context.Products.Include(x => x.Category).Where(x => x.State == 1 && x.ProductTitle.Contains(search)).ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var data in query)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.Id = data.Id;
                productViewModel.ProductTitle = data.ProductTitle;
                productViewModel.ProductDescription = data.ProductDescription;
                productViewModel.CategoryId = data.Category.Id;
                productViewModel.CategoryName = data.Category.Name;
                productViewModel.EntryDate = data.EntryDate;
                productViewModel.EntryMonth = data.EntryMonth;
                productViewModel.EntryYear = data.EntryYear;
                productViewModel.BasePrice = data.BasePrice;
                productViewModel.SellPrice = data.SellPrice;
                productViewModel.Profit = data.Profit;
                productViewModel.ActionBy = data.ActionBy;
                productViewModel.ActionDone = data.ActionDone;
                productViewModel.ActionTime = data.ActionTime;
                productViewModel.Quantity = data.Quantity;
                productViewModel.PictureUrl = data.PictureUrl;

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public List<ProductViewModel> SearchByCategoryAndTitle(string searchString, int categoryId)
        {
            var query = context.Products.Include(x => x.Category).Where(x => x.State == 1 && x.ProductTitle.Contains(searchString) && x.CategoryId == categoryId).ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var data in query)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.Id = data.Id;
                productViewModel.ProductTitle = data.ProductTitle;
                productViewModel.ProductDescription = data.ProductDescription;
                productViewModel.CategoryId = data.Category.Id;
                productViewModel.CategoryName = data.Category.Name;
                productViewModel.EntryDate = data.EntryDate;
                productViewModel.EntryMonth = data.EntryMonth;
                productViewModel.EntryYear = data.EntryYear;
                productViewModel.BasePrice = data.BasePrice;
                productViewModel.SellPrice = data.SellPrice;
                productViewModel.Profit = data.Profit;
                productViewModel.ActionBy = data.ActionBy;
                productViewModel.ActionDone = data.ActionDone;
                productViewModel.ActionTime = data.ActionTime;
                productViewModel.Quantity = data.Quantity;
                productViewModel.PictureUrl = data.PictureUrl;

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public int NumberOfStockOutRangeItems()
        {
            return context.Products.Where(x => x.Quantity <= 10 && x.State == 1).ToList().Count;
        }
    }
}
