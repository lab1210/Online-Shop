using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface ICategoryService
    {
        Category AddCategory(Category category);
        void DeleteCategory(int ID);
        IEnumerable<Category> GetAllCategories();
        IEnumerable<CategoryMemo> GetCategory();
        IEnumerable<ProductResource> GetproductbyCategory(int categoryid);
    }
}
