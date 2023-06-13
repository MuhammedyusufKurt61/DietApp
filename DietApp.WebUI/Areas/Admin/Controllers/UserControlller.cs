using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebUI.Areas.Admin.Controllers
{
    public class UserControlller : Controller
    {
        // GET: UserControlller
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserControlller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserControlller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserControlller/Create
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

        // GET: UserControlller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserControlller/Edit/5
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

        // GET: UserControlller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserControlller/Delete/5
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
