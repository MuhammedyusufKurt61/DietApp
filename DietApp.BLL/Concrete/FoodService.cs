using DietApp.BLL.Abstract;
using DietApp.DAL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.FoodViewModels;
using DietApp.ViewModels.MealViewModesl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Concrete
{
    public class FoodService : IFoodBLL
    {
        private readonly IFoodDAL _foodDAL;
        public FoodService(IFoodDAL foodDAL)
        {
            _foodDAL = foodDAL;
        }

        public bool AnyFood(string foodName)
        {
            bool validFood = _foodDAL.GetAll(x => x.IsActive).Any(x => x.FoodName.Equals(foodName));
            return validFood;
        }

        public ResultService<Food> CreateFood(FoodCreateVM vm)
        {
            ResultService<Food> result = new ResultService<Food>();
            bool checkFood = AnyFood(vm.FoodName);
            if (!checkFood)
            {
                Food newFood = new Food()
                {
                    FoodName = vm.FoodName
                };
                Food addFood = _foodDAL.Add(newFood);
                result.Data = addFood ?? newFood;
                if (addFood == null)
                {
                    result.AddError("Hata Oluştu", "Ekleme İşlemi Başarısız.");
                }
            }
            else
            {
                result.Data = new Food
                {
                    FoodName = vm.FoodName
                };
                result.AddError("Kayıt mevcut", "Ekleme Başarısız");
            }
            return result;
        }

        public ResultService<FoodBaseVM> DeleteFoodById(int id)
        {
            ResultService<FoodBaseVM> result = new ResultService<FoodBaseVM>();
            try
            {
                Food food = _foodDAL.Get(x => x.Id.Equals(id) && x.IsActive);
                food.IsActive = false;
                _foodDAL.Delete(food);

                result.Data = new FoodBaseVM
                {
                    Id = food.Id,
                    Name = food.FoodName
                };
            }
            catch (Exception)
            {
                result.AddError("Silme İşlemi Başarısız.", "Kayıt Bulunamadı.");
            }
            return result;
        }

        public ResultService<Food> GetAllFoods()
        {
            throw new NotImplementedException();
        }

        public ResultService<FoodUpdateVM> GetFood(int id)
        {
            throw new NotImplementedException();
        }

        public ResultService<Food> GetFoodByName(string foodName)
        {
            throw new NotImplementedException();
        }

        public ResultService<FoodBaseVM> GetFoodId(string foodName)
        {
            ResultService<FoodBaseVM> result = new ResultService<FoodBaseVM>();
            Food food = _foodDAL.Get(x => x.IsActive && x.FoodName == foodName);
            if (food != null)
            {
                result.Data = new FoodBaseVM
                {
                    Id = food.Id,
                    Name = foodName
                };
            }
            else
            {
                result.Data = new FoodBaseVM
                {
                    Id = -1,
                    Name = foodName
                };
                result.AddError("Kayıt Bulunamadı", "Bu isimde bir besin yok");
            }
            return result;
        }

        public ResultService<FoodUpdateVM> UpdateFood(FoodUpdateVM vm)
        {
            ResultService<FoodUpdateVM> result = new ResultService<FoodUpdateVM>();
            Food food = _foodDAL.Get(x => x.IsActive && x.Id == vm.Id);
            if (!AnyFood(vm.Name))
            {
                food.FoodName = vm.Name;
                food.UpdateOn = vm.UpdateDate;
                Food updateFood = _foodDAL.Update(food);
                if (updateFood != null)
                {
                    result.Data = new FoodUpdateVM
                    {
                        Id = updateFood.Id,
                        Name = updateFood.FoodName
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
