using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using BdMarketWebApp.Utility;

namespace BdMarketWebApp.Manager
{
    public class ProductManager
    {
        private UnitOfWork unitOfWork;

        public ProductManager()
        {
            unitOfWork = new UnitOfWork();
        }

        // save product
        public string Save(Product product)
        {
            if (unitOfWork.Product.IsExists(x => x.ProductTitle == product.ProductTitle && x.State == 1))
            {
                return BootstrapMessages.Warning("Same Title Product Already Exists");
            }
            else
            {
                unitOfWork.Product.Add(product);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return BootstrapMessages.Success("Product Entry Successfully");
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Entry New Product");
                }
            }
        }

        // get all product
        public List<ProductViewModel> GetAllProducts()
        {
            return unitOfWork.Product.GetAllProducts();
        }

        // check product exists
        public bool IsProductExists(int id)
        {
            return unitOfWork.Product.IsExists(x => x.Id == id && x.State == 1);
        }

        // get by id for details
        public ProductViewModel GetProductByIdForDetails(int id)
        {
            return unitOfWork.Product.ViewProduct(id);
        }

        // convert view model to model
        public Product ConvertViewModelToModel(ProductViewModel productViewModel)
        {
            Product product = new Product();

            product.Id = productViewModel.Id;
            product.ProductTitle = productViewModel.ProductTitle;
            product.ProductDescription = productViewModel.ProductDescription;
            product.EntryDate = productViewModel.EntryDate;
            product.BasePrice = productViewModel.BasePrice;
            product.SellPrice = productViewModel.SellPrice;
            product.Profit = productViewModel.Profit;
            product.ActionBy = productViewModel.ActionBy;
            product.ActionDone = productViewModel.ActionDone;
            product.ActionTime = productViewModel.ActionTime;
            product.Quantity = productViewModel.Quantity;
            product.PictureUrl = productViewModel.PictureUrl;

            return product;
        }

        // get by id
        public Product GetById(int id)
        {
            return unitOfWork.Product.Get(x => x.Id == id && x.State == 1);
        }

        // update
        public string Update(Product product)
        {
            if (unitOfWork.Product.IsExists(x =>
                x.ProductTitle == product.ProductTitle && x.State == 1 && x.Id != product.Id))
            {
                return BootstrapMessages.Warning("Product Title already exists");
            }
            else
            {
                unitOfWork.Product.Update(product);
                int rowsAffected = unitOfWork.Completed();

                if (rowsAffected > 0)
                {
                    return "1";
                }
                else
                {
                    return BootstrapMessages.Failed("Failed to Update Product");
                }
            }
        }

        // remove
        public void Remove(Product product)
        {
            unitOfWork.Product.Update(product);
            unitOfWork.Completed();
        }

        // take top items
        public List<ProductViewModel> TakeTopItems(int items)
        {
            int rows = unitOfWork.Product.RowCount();

            if (rows < items)
            {
                return unitOfWork.Product.TopItems(rows);
            }
            else
            {
                return unitOfWork.Product.TopItems(items);
            }
        }

        // take related product by category id
        public List<ProductViewModel> GetRelatedProductsByCategoryId(int categoryId, int num)
        {
            int rows = unitOfWork.Product.RowCountForRelatedItems(categoryId);

            if (rows <= num)
            {
                return unitOfWork.Product.GetRelatedProductByCategory(categoryId, rows);
            }
            else
            {
                return unitOfWork.Product.GetRelatedProductByCategory(categoryId, num);
            }
        }

        // take all items by category id
        public List<ProductViewModel> GetAllItemsByCategory(int categoryId)
        {
            return unitOfWork.Product.GetItemsByCategoryId(categoryId);
        }

        // search by title
        public List<ProductViewModel> SearchItem(string searchString)
        {
            return unitOfWork.Product.SearchItem(searchString);
        }

        // search by title and category
        public List<ProductViewModel> SearchByTitleAndCategory(string search, int categoryId)
        {
            return unitOfWork.Product.SearchByCategoryAndTitle(search, categoryId);
        }
    }
}
