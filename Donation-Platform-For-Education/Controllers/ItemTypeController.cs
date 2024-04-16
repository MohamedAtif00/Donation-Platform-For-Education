using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Donation_Platform_For_Education.Controllers
{
    public class ItemTypeController : Controller
    {
        // GET: ItemTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ItemTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemTypeController/Create
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

        // GET: ItemTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemTypeController/Edit/5
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

        // GET: ItemTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemTypeController/Delete/5
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
