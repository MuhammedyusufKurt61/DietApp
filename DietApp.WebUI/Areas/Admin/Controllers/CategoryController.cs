using DietApp.BLL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.CategoryViewModels;
using DietApp.ViewModels.MealViewModesl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoryController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            ResultService<CategoryBaseVM> result = new ResultService<CategoryBaseVM>();
            result.ListData = _categoryBLL.GetAllCategories().ListData.Select(x => new CategoryBaseVM
            {
                Id = x.Id,
                Name = x.CategoryName
            }).ToList();

            return View(result.ListData);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            ResultService<CategoryBaseVM> result = _categoryBLL.GetCategoryId(id);

            if (result.HasError)
            {
                ViewBag.ErrorMessage = result.ErrorItems.First().ErrorMessage;
                ViewBag.ErrorType = result.ErrorItems.First().ErrorType;
            }

            return View(result.Data);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreateVM vm)
        {
            ResultService<Category> result = _categoryBLL.CreateCategory(vm);

            if (result.HasError)
            {
                ViewBag.ErrorMessage = result.ErrorItems.First().ErrorMessage;
                ViewBag.ErrorType = result.ErrorItems.First().ErrorType;
                return View(vm);
            }

            TempData["Success"] = "Kayıt Başarılı";
            return RedirectToAction(nameof(Index));

        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            ResultService<CategoryUpdateVM> result = _categoryBLL.GetCategory(id);
            if (result.HasError)
            {
                ViewData["ErrorMesage"] = result.ErrorItems.First().ErrorMessage;
                ViewData["ErrorType"] = result.ErrorItems.First().ErrorType;
            }
            
            return View(result.Data);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryUpdateVM vm)
        {
            ResultService<CategoryUpdateVM> result = _categoryBLL.UpdateCategory(vm);

            if (result.HasError)
            {
                ViewData["ErrorMesage"] = result.ErrorItems.First().ErrorMessage;
                ViewData["ErrorType"] = result.ErrorItems.First().ErrorType;
                return View(vm);
            }

            TempData["Success"] = "Güncelleme başarılı";

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            ResultService<CategoryBaseVM> result = _categoryBLL.DeleteCategoryById(id);

            if (result.HasError)
            {
                ViewData["ErrorMesage"] = result.ErrorItems.First().ErrorMessage;
                ViewData["ErrorType"] = result.ErrorItems.First().ErrorType;

                return RedirectToAction("Index");
            }
            else
            {
                string message = "Silme işlemi başarılı";
                string deletedName = result.Data.Name;

                TempData["Success"] = message + " " + deletedName;
            }

            return RedirectToAction("Index");
        }

        
    }
}
