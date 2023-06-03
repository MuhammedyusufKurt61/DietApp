using DietApp.BLL.Abstract;
using DietApp.DAL.Abstract;
using DietApp.Entity;
using DietApp.System;
using DietApp.ViewModels.CategoryViewModels;
using DietApp.ViewModels.MealViewModesl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Concrete
{
    public class MealService: IMealBLL
    {
        private readonly IMealDAL _mealDAL;
        public MealService(IMealDAL mealDAL)
        {
            _mealDAL = mealDAL;
        }

        public bool AnyMeal(string mealName)
        {
            bool validMeal = _mealDAL.GetAll(x => x.IsActive).Any(x => x.MealName.Equals(mealName));
            return validMeal;
        }

        public ResultService<Meal> CreateMeal(MealCreateVM vm)
        {
            ResultService<Meal> result = new ResultService<Meal>();
            bool checkMeal = AnyMeal(vm.MealName);
            if (!checkMeal)
            {
                Meal newMeal = new Meal()
                {
                    MealName = vm.MealName
                };
                Meal addMeal = _mealDAL.Add(newMeal);
                result.Data = addMeal ?? newMeal;
                if (addMeal == null)
                {
                    result.AddError("Hata Oluştu", "Ekleme İşlemi Başarısız.");
                }
            }
            else
            {
                result.Data = new Meal
                {
                    MealName = vm.MealName
                };
                result.AddError("Kayıt mevcut", "Ekleme Başarısız");
            }
            return result;
        }

        public ResultService<MealBaseVM> DeleteMealById(int id)
        {
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            try
            {
                Meal meal = _mealDAL.Get(x => x.Id.Equals(id) && x.IsActive);
                meal.IsActive = false;
                _mealDAL.Delete(meal);

                result.Data = new MealBaseVM
                {
                    Id = meal.Id,
                    Name = meal.MealName
                };
            }
            catch (Exception)
            {
                result.AddError("Silme İşlemi Başarısız.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<Meal> GetAllMeals()
        {
            throw new NotImplementedException();
        }

        public ResultService<MealUpdateVM> GetMeal(int id)
        {
            throw new NotImplementedException();
        }

        public ResultService<Meal> GetMealByName(string mealName)
        {
            throw new NotImplementedException();
        }

        public ResultService<MealBaseVM> GetMealId(string mealName)
        {
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            Meal meal = _mealDAL.Get(x => x.IsActive && x.MealName == mealName);
            if (meal != null)
            {
                result.Data = new MealBaseVM
                {
                    Id = meal.Id,
                    Name = mealName
                };
            }
            else
            {
                result.Data = new MealBaseVM
                {
                    Id = -1,
                    Name = mealName
                };
                result.AddError("Kayıt Bulunamadı", "Bu isimde bir öğün yok");
            }
            return result;
        }

        public ResultService<MealUpdateVM> UpdateMeal(MealUpdateVM vm)
        {
            ResultService<MealUpdateVM> result = new ResultService<MealUpdateVM>();
            Meal meal = _mealDAL.Get(x => x.IsActive && x.Id == vm.Id);
            if (!AnyMeal(vm.Name))
            {
                meal.MealName = vm.Name;
                meal.UpdateOn = vm.UpdateDate;
                Meal updateMeal = _mealDAL.Update(meal);
                if (updateMeal != null)
                {
                    result.Data = new MealUpdateVM
                    {
                        Id = updateMeal.Id,
                        Name = updateMeal.MealName
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
