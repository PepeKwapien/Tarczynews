using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarczynews.Models;

namespace Tarczynews.Controllers
{
    public class CapsController : Controller
    {
        IList<TarczynCap> tarczynCaps;

        public CapsController()
        {
            tarczynCaps = new List<TarczynCap>();
        }

        // GET: CapsController
        public ActionResult Index()
        {
            return View(tarczynCaps);
        }

        // GET: CapsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CapsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CapsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarczynCap tarczynCap)
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

        // GET: CapsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CapsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id)
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

        // GET: CapsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CapsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
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
