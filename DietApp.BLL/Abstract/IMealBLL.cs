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
        ResultService<Meal> CreateMeal(MealCreateVM vm);
        ResultService<MealUpdateVM> UpdateMeal(MealUpdateVM vm);
        ResultService<MealBaseVM> DeleteMealById(int id);
        ResultService<Meal> GetMealByName(string mealName);
        ResultService<Meal> GetMealById(int id);
        ResultService<MealBaseVM> GetAllMeals();
        bool AnyMeal(string MealName);
    }

}
