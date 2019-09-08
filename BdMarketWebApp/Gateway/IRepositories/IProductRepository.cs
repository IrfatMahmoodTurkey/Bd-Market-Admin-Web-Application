using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;

namespace BdMarketWebApp.Gateway.IRepositories
{
    public interface IProductRepository:IRepository<Product>
    {
        int RowCount();
        List<ProductViewModel> GetAllProducts();
        ProductViewModel ViewProduct(int id);
        List<ProductViewModel> TopItems(int item);
        List<ProductViewModel> GetRelatedProductByCategory(int categoryId, int num);
        int RowCountForRelatedItems(int categoryId);
        List<ProductViewModel> GetItemsByCategoryId(int categoryId);
        List<ProductViewModel> SearchItem(string search);
        List<ProductViewModel> SearchByCategoryAndTitle(string searchString, int categoryId);
        int NumberOfStockOutRangeItems();
    }
}
