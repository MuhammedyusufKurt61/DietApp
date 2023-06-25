using DietApp.BLL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.MealViewModesl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MealController : Controller
    {
        private readonly IMealBLL _mealBLL;

        public MealController(IMealBLL mealBLL)
        {
            _mealBLL = mealBLL;
        }

        // GET: MealController
        public ActionResult Index()
        {
            ResultService<MealBaseVM> result = _mealBLL.GetAllMeals();
            return View(result);
        }
                
        // GET: MealController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreateVM vm)
        {
            ResultService<Meal> result = _mealBLL.CreateMeal(vm);
            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorMessage;

                ViewData["Errors"] = errorMessage +"\n" + errorType;
                return View(vm);//Hata ile birlikte gelen veriyi de geri döndürecek.
            }

            TempData["Success"] = result.Data.MealName + "\n" + "Kayıt işlemi başarılı";
            return RedirectToAction("Index");
           
        }

        // GET: MealController/Update/5
        public ActionResult Update(int id)
        {
            ResultService<Meal> result = _mealBLL.GetMealById(id);
            MealUpdateVM updateVM = new MealUpdateVM()
            {
                Id = result.Data.Id,
                MealName = result.Data.MealName,
            };

            return View(updateVM);
        }

        // POST: MealController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MealUpdateVM vm)
        {
            ResultService<MealUpdateVM> result = _mealBLL.UpdateMeal(vm);

            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorMessage;

                ViewData["Errors"] = errorMessage + "\n" + errorType;
                return View(vm);//Hata ile birlikte gelen veriyi de geri döndürecek.
            }
            TempData["Success"] = result.Data.MealName + "\n" + "Güncelleme işlemi başarılı";
            return RedirectToAction("Index");
        }

        // GET: MealController/Delete/5
        public ActionResult Delete(int id)
        {
            ResultService<MealBaseVM> result = _mealBLL.DeleteMealById(id);

            if (result.HasError)
            {
                string errorMessage = result.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = result.ErrorItems.ToList()[0].ErrorMessage;

                TempData["Errors"] = errorMessage + "\n" + errorType;                
            }
            else
            {
                string message = "Silme işlemi başarılı";
                string deletedName = result.Data.MealName;

                TempData["Success"] = message+ " " + deletedName;
            }
           
            return RedirectToAction("Index");
        }

    }
}
