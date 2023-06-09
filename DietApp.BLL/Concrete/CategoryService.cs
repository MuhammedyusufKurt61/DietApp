﻿using DietApp.BLL.Abstract;
using DietApp.DAL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Concrete
{
    public class CategoryService : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public bool AnyCategory(string categoryName)
        {
            bool validCategory = _categoryDAL.GetAll(x => x.IsActive).Any(x => x.CategoryName.Equals(categoryName));
            return validCategory;
        }

        public ResultService<Category> CreateCategory(CategoryCreateVM vm)
        {
            ResultService<Category> result = new ResultService<Category>();
            bool checkCategory = AnyCategory(vm.CategoryName);
            if (!checkCategory)
            {
                Category newCategory = new Category()
                {
                    CategoryName = vm.CategoryName,
                    CreateOn = vm.CreateDate
                };
                Category addCategory = _categoryDAL.Add(newCategory);
                result.Data = addCategory ?? newCategory;
                if (addCategory == null)
                {
                    result.AddError("Hata Oluştu", "Ekleme İşlemi Başarısız.");
                }
            }
            else
            {
                result.Data = new Category
                {
                    CategoryName = vm.CategoryName
                };
                result.AddError("Kayıt mevcut", "Ekleme Başarısız");
            }
            return result;
        }

        public ResultService<CategoryBaseVM> DeleteCategoryById(int id)
        {
            ResultService<CategoryBaseVM> result = new ResultService<CategoryBaseVM>();
            try
            {
                Category category = _categoryDAL.Get(x => x.Id.Equals(id) && x.IsActive);
                category.IsActive = false;
                _categoryDAL.Delete(category);

                result.Data = new CategoryBaseVM
                {
                    Id = category.Id,
                    Name = category.CategoryName
                };
            }
            catch (Exception)
            {
                result.AddError("Silme İşlemi Başarısız.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<Category> GetAllCategories()
        {
            ResultService<Category> result = new ResultService<Category>();

            List<Category> categories = _categoryDAL.GetAll(x => x.IsActive, x => x.Foods).ToList();
            result.ListData = categories;

            return result;
        }

        public ResultService<CategoryUpdateVM> GetCategory(int id)
        {
            ResultService<CategoryUpdateVM> result = new ResultService<CategoryUpdateVM>();
            Category category = _categoryDAL.Get(x => x.Id.Equals(id) && x.IsActive);

            if (category != null)
            {
                result.Data = new CategoryUpdateVM
                {
                    Id = category.Id,
                    Name = category.CategoryName
                };
            }
            else
            {
                result.AddError("Kayıt Bulunamadı", "Kayıt Bulunamadı");
            }

            return result;
        }

        public ResultService<Category> GetCategoryByName(string categoryName)
        {
            ResultService<Category> result = new ResultService<Category>();
            Category category = _categoryDAL.Get(x => x.IsActive && x.CategoryName == categoryName);

            if (category != null)
            {
                result.Data = category;                
            }
            else
            {
                result.Data = new Category
                {
                    Id = -1,
                    CategoryName = categoryName
                };
                result.AddError("Kayıt Bulunamadı", "Bu isimde kategori mevcut değil"); 
            }
            return result;
        }

        public ResultService<CategoryBaseVM> GetCategoryId(int id)
        {
            ResultService<CategoryBaseVM> result = new ResultService<CategoryBaseVM>();
            Category category = _categoryDAL.Get(x => x.Id.Equals(id) && x.IsActive);
            if (category != null)
            {
                result.Data = new CategoryBaseVM
                {
                    Id = category.Id,
                    Name = category.CategoryName
                };
            }
            else
            {
                result.Data = new CategoryBaseVM
                {
                    Id = -1,
                    Name = category.CategoryName
                };
                result.AddError("Kayıt Bulunamadı", "Bu isimde bir kategori yok");
            }
            return result;
        }

        public ResultService<CategoryUpdateVM> UpdateCategory(CategoryUpdateVM vm)
        {
            ResultService<CategoryUpdateVM> result = new ResultService<CategoryUpdateVM>();
            Category category = _categoryDAL.Get(x => x.IsActive && x.Id == vm.Id);
            if (!AnyCategory(vm.Name))
            {
                category.CategoryName = vm.Name;
                category.UpdateOn = vm.UpdateDate;
                Category updateCategory = _categoryDAL.Update(category);
                if (updateCategory != null)
                {
                    result.Data = new CategoryUpdateVM
                    {
                        Id = updateCategory.Id,
                        Name = updateCategory.CategoryName
                    };
                }
                else
                {
                    result.AddError("Hata", "Güncelleme Başarısız");
                }
            }

            else
            {
                result.Data = vm;
                result.AddError("Güncelleme Başarısız.", "Kayıt Bulunamadı.");
            }

            return result;
        }
    }
}
