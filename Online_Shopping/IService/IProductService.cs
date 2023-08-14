using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface IProductService
    {
        Product SaveProduct(Product product);
        IEnumerable<ProductResource> GetAllProducts();
        IEnumerable<ProductResource> ProductSearch(string searchname);

        IEnumerable<ProductReport> GetInventory();

        void DeleteProduct(string slug);
        void UpdateProduct(ProductResource product);
        ProductResource GetProductBySlug(string slug);

         IEnumerable<ProductReport> Stock();
        IEnumerable<ProductResource> GetRelatedProductsByCategory(int categoryId);
      

       


    }
}
