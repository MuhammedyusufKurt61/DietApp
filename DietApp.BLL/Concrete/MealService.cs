using DietApp.BLL.Abstract;
using DietApp.DAL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using DietApp.ViewModels.MealViewModesl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Concrete
{
    public class MealService : IMealBLL
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

            Meal newMeal = new Meal()
            {
                MealName = vm.MealName,
                CreateOn = vm.CreateOn,
            };
            Meal addMeal = _mealDAL.Add(newMeal);
            if (addMeal == null)
            {
                result.AddError("Hata Oluştu", "Ekleme İşlemi Başarısız.");
            }
            result.Data = addMeal ?? newMeal;

            //bool checkMeal = AnyMeal(vm.MealName);
            //if (!checkMeal)
            //{
            //    Meal newMeal = new Meal()
            //    {
            //        MealName = vm.MealName,
            //        CreateOn= vm.CreateOn,
            //    };
            //    Meal addMeal = _mealDAL.Add(newMeal);
            //    result.Data = addMeal ?? newMeal;
            //    if (addMeal == null)
            //    {
            //        result.AddError("Hata Oluştu", "Ekleme İşlemi Başarısız.");
            //    }
            //}
            //else
            //{
            //    result.Data = new Meal
            //    {
            //        MealName = vm.MealName,
            //        CreateOn= vm.CreateOn,
            //    };
            //    result.AddError("Kayıt mevcut", "Ekleme Başarısız");
            //}

            return result;
        }

        public ResultService<MealBaseVM> DeleteMealById(int id)
        {
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            try
            {
                Meal meal = _mealDAL.Get(x => x.Id.Equals(id) && x.IsActive);
                meal.IsActive = false;
                result.Data = new MealBaseVM
                {
                    Id = meal.Id,
                    MealName = meal.MealName
                };

                _mealDAL.Delete(meal);
            }
            catch (Exception)
            {
                result.AddError("Silme İşlemi Başarısız.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<MealBaseVM> GetAllMeals()
        {
            ResultService<MealBaseVM> result = new ResultService<MealBaseVM>();
            List<MealBaseVM> baseList = _mealDAL.GetAll(x => x.IsActive)
                                         .Select(x => new MealBaseVM()
                                         {
                                             Id = x.Id,
                                             MealName = x.MealName
                                         }).ToList();
            if (baseList.Count > 0)
            {
                result.ListData = baseList;
            }
            else
            {
                result.AddError("Hata!", "Verilere ulaşılamadı");
            }
            return result;
        }

        public ResultService<Meal> GetMealById(int id)
        {
            ResultService<Meal> result = new ResultService<Meal>();
            result.Data = _mealDAL.Get(x => x.IsActive && x.Id == id);
            if (result.Data == null)
            {
                result.AddError("Kayıt bulunamadı", "Kayıt Bulunamadı");
            }
            return result;
        }

        public ResultService<Meal> GetMealByName(string mealName)
        {
            ResultService<Meal> result = new ResultService<Meal>();
            result.Data = _mealDAL.Get(x => x.IsActive && x.MealName.Equals(mealName));
            if (result.Data == null)
            {
                result.AddError("Kayıt bulunamadı", "Kayıt Bulunamadı");
            }
            return result;
        }


        public ResultService<MealUpdateVM> UpdateMeal(MealUpdateVM vm)
        {
            ResultService<MealUpdateVM> result = new ResultService<MealUpdateVM>();
            try
            {
                Meal meal = _mealDAL.Get(x => x.IsActive && x.Id == vm.Id);
                meal.MealName = vm.MealName;
                meal.UpdateOn = vm.UpdateDate;

                Meal updateMeal = _mealDAL.Update(meal);
                result.Data = vm;
            }
            catch (Exception)
            {
                result.Data = vm;
                result.AddError("Güncelleme Başarısız.", "Kayıt Bulunamadı.");
            }

            return result;
        }
    }
}
