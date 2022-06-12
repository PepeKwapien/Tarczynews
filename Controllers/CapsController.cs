using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarczynews.Models;
using System.Linq;

namespace Tarczynews.Controllers
{
    public class CapsController : Controller
    {
        public static IList<TarczynCap> tarczynCaps = new List<TarczynCap>();

        // GET: CapsController
        public ActionResult Index()
        {
            return View(tarczynCaps);
        }

        // GET: CapsController/Details/5
        public ActionResult Details(int id)
        {
            var cap = tarczynCaps.FirstOrDefault(x => x.Number == id);
            return cap != null ? View(cap) : View("Index");
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
                tarczynCaps.Add(new TarczynCap() { Id = Guid.NewGuid(), City = tarczynCap.City,
                    Number = tarczynCap.Number, Message = tarczynCap.Message});
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
            var cap = tarczynCaps.FirstOrDefault(x => x.Number == id);
            return cap != null ? View(cap) : View("Index");
        }

        // POST: CapsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(TarczynCap cap)
        {
            try
            {
                var model = tarczynCaps.FirstOrDefault(x => x.Id == cap.Id);
                if (model != null)
                {
                    model.Number = cap.Number;
                    model.City = cap.City;
                    model.Message = cap.Message;
                }
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
            var cap = tarczynCaps.FirstOrDefault(x => x.Number == id);
            return cap != null ? View(cap) : View("Index");
        }

        // POST: CapsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(Guid id)
        {
            try
            {
                var cap = tarczynCaps.FirstOrDefault(x => x.Id == id);
                if (cap != null)
                {
                    tarczynCaps.Remove(cap);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
