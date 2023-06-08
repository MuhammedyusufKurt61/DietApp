using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using DietApp.ViewModels.MealViewModesl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Abstract
{
    public interface IMealBLL : IBaseBLL<Meal>
    {
        ResultService<MealBaseVM> GetMealId(string mealName);
        ResultService<Meal> GetAllMeals();
        ResultService<Meal> GetMealByName(string mealName);
        ResultService<MealBaseVM> DeleteMealById(int id);
        ResultService<MealUpdateVM> UpdateMeal(MealUpdateVM vm);
        ResultService<Meal> CreateMeal(MealCreateVM vm);
        ResultService<MealUpdateVM> GetMeal(int id);
        bool AnyMeal(string MealName);
    }

}
