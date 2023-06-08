using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using DietApp.ViewModels.FoodViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Abstract
{
    public interface IFoodBLL : IBaseBLL<Food>
    {
        ResultService<FoodBaseVM> GetFoodId(string foodName);
        ResultService<Food> GetAllFoods();
        ResultService<Food> GetFoodByName(string foodName);
        ResultService<FoodBaseVM> DeleteFoodById(int id);
        ResultService<FoodUpdateVM> UpdateFood(FoodUpdateVM vm);
        ResultService<Food> CreateFood(FoodCreateVM vm);
        ResultService<FoodUpdateVM> GetFood(int id);
        /// <summary>
        /// Girilen isimde bir besinin var olup olmadığını döndürür.
        /// Besin detayında sadece ismi içerir.
        /// </summary>
        /// <param name="foodName"></param>
        /// <returns>bool</returns>
        bool AnyFood(string foodName);
    }
}
