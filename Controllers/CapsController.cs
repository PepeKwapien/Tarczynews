using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarczynews.Models;
using System.Linq;
using Tarczynews.Data;

namespace Tarczynews.Controllers
{
    public class CapsController : Controller
    {
        public static IList<TarczynCap> tarczynCaps = new List<TarczynCap>();
        private readonly TarczynCapContext _context;

        public CapsController(TarczynCapContext tarczynCapContext)
        {
            _context = tarczynCapContext;
        }

        // GET: CapsController
        public ActionResult Index()
        {
            return View(_context.ReadAllTarczynCaps());
        }

        // GET: CapsController/Details/5
        public ActionResult Details(int number)
        {
            var cap = _context.ReadTarczynCapByNumber(number);
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
            var storedCap = tarczynCaps.FirstOrDefault(cap => cap.Number == tarczynCap.Number);

            if(storedCap != null)
            {
                TempData["Error"] = "You already have cap with this number";

                return View(tarczynCap);
            }

            tarczynCaps.Add(new TarczynCap()
            {
                Id = Guid.NewGuid(),
                City = tarczynCap.City,
                Number = tarczynCap.Number,
                Message = tarczynCap.Message
            });
            TempData["Success"] = $"Cap {tarczynCap.Number} was created successfully";

            return RedirectToAction(nameof(Index));
        }

        // GET: CapsController/Edit/5
        public ActionResult Edit(int id)
        {
            var cap = tarczynCaps.FirstOrDefault(x => x.Number == id);

            return cap != null ? View(cap) : View("Index");
        }

        // POST: CapsController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(TarczynCap tarczynCap)
        {
            var storedCap = tarczynCaps.FirstOrDefault(x => x.Id == tarczynCap.Id);

            if(storedCap?.Number != tarczynCap.Number)
            {
                var storedCapWithNumber = tarczynCaps.FirstOrDefault(x => x.Number == tarczynCap.Number);

                if(storedCapWithNumber != null)
                {
                    TempData["Error"] = "There is a cap with this number already";

                    return View("Edit", tarczynCap);
                }
            }

            if (storedCap != null)
            {
                storedCap.Number = tarczynCap.Number;
                storedCap.City = tarczynCap.City;
                storedCap.Message = tarczynCap.Message;

                TempData["Success"] = $"Cap {tarczynCap.Number} edited successfully";
            }

            return RedirectToAction(nameof(Index));
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
            var cap = tarczynCaps.FirstOrDefault(x => x.Id == id);
            if (cap != null)
            {
                tarczynCaps.Remove(cap);

                TempData["Success"] = $"Cap {cap.Number} removed successfully";
            }
            else
            {
                TempData["Error"] = $"Deleting cap was not successful";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
