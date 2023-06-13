using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebUI.Areas.Admin.Controllers
{
    public class MealController : Controller
    {
        // GET: MealController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MealController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MealController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MealController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MealController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MealController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
