using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarczynews.Models;
using System.Linq;
using Tarczynews.Data;
using Tarczynews.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Tarczynews.Controllers
{
    [Authorize]
    public class CapsController : Controller
    {
        private readonly ITarczynCapRepository _tarczynCapRepository;

        public CapsController(ITarczynCapRepository tarczynCapRepository)
        {
            _tarczynCapRepository = tarczynCapRepository;
        }

        // GET: CapsController
        public ActionResult Index()
        {
            return View(_tarczynCapRepository.ReadAllTarczynCapsForEmailSortedAscendingByNumber(User.Identity?.Name ?? ""));
        }

        // GET: CapsController/Details/5
        public ActionResult Details(int number)
        {
            var cap = _tarczynCapRepository.ReadTarczynCapByNumber(number);

            if (cap == null)
            {
                TempData["Error"] = "You do not have cap with this number";

                return View("Index");
            }

            return View(cap);
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
            var storedCap = _tarczynCapRepository.ReadTarczynCapByNumber(tarczynCap.Number);

            if(storedCap != null)
            {
                TempData["Error"] = "You already have cap with this number";

                return View(tarczynCap);
            }

            _tarczynCapRepository.Create(tarczynCap);
            _tarczynCapRepository.Save();

            TempData["Success"] = $"Cap {tarczynCap.Number} was created successfully";

            return RedirectToAction(nameof(Index));
        }

        // GET: CapsController/Edit/5
        public ActionResult Edit(int number)
        {
            var cap = _tarczynCapRepository.ReadTarczynCapByNumber(number);

            if (cap == null)
            {
                TempData["Error"] = "You do not have cap with this number";

                return View("Index");
            }

            return View(cap);
        }

        // POST: CapsController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(TarczynCap tarczynCap)
        {
            var storedCap = _tarczynCapRepository.Read(tarczynCap.Id);

            if(storedCap == null)
            {
                TempData["Error"] = "There was an error while trying to find this cap";
            }
            else
            {
                if (storedCap.Number != tarczynCap.Number)
                {
                    var storedCapWithNumber = _tarczynCapRepository.ReadTarczynCapByNumber(tarczynCap.Number);

                    if (storedCapWithNumber != null)
                    {
                        TempData["Error"] = "There is a cap with this number already";

                        return View("Edit", tarczynCap);
                    }
                }

                _tarczynCapRepository.Update(tarczynCap);
                _tarczynCapRepository.Save();

                TempData["Success"] = $"Cap {tarczynCap.Number} was updated successfully";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CapsController/Delete/5
        public ActionResult Delete(int number)
        {
            var cap = _tarczynCapRepository.ReadTarczynCapByNumber(number);

            if (cap == null)
            {
                TempData["Error"] = "You do not have cap with this number";

                return View("Index");
            }

            return View(cap);
        }

        // POST: CapsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(Guid id)
        {
            var cap = _tarczynCapRepository.Read(id);
            if (cap != null)
            {
                var number = cap.Number;
                _tarczynCapRepository.Delete(id);
                _tarczynCapRepository.Save();

                TempData["Success"] = $"Cap {number} removed successfully";
            }
            else
            {
                TempData["Error"] = $"Deleting cap was not successful";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
