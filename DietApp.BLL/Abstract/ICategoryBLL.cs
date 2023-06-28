using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Abstract
{
    public interface ICategoryBLL : IBaseBLL<Category>
    {
        ResultService<CategoryBaseVM> GetCategoryId(int id);
        ResultService<Category> GetAllCategories();
        ResultService<Category> GetCategoryByName(string categoryName);
        ResultService<CategoryBaseVM> DeleteCategoryById(int id);
        ResultService<CategoryUpdateVM> UpdateCategory(CategoryUpdateVM vm);
        ResultService<Category> CreateCategory(CategoryCreateVM vm);
        ResultService<CategoryUpdateVM> GetCategory(int id);
        bool AnyCategory(string categoryName);
    }
}
