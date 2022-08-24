using Microsoft.AspNetCore.Mvc;
using Tarczynews.Models;
using Tarczynews.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Tarczynews.Controllers
{
    [Authorize]
    public class CapsController : Controller
    {
        private readonly ITarczynCapRepository _tarczynCapRepository;
        private readonly ITarczynewsUserRepository _tarczynewsUserRepository;

        public CapsController(ITarczynCapRepository tarczynCapRepository, ITarczynewsUserRepository tarczynewsUserRepository)
        {
            _tarczynCapRepository = tarczynCapRepository;
            _tarczynewsUserRepository = tarczynewsUserRepository;
        }

        // GET: CapsController
        public ActionResult Index()
        {
            return View(_tarczynCapRepository.ReadAllTarczynCapsForUsernameSortedAscendingByNumber(User.Identity?.Name ?? ""));
        }

        // GET: CapsController/Details/5
        public ActionResult Details(int number)
        {
            var cap = _tarczynCapRepository.ReadTarczynCapByNumberAndOwnerUsername(number, _tarczynewsUserRepository.ReadCurrent().UserName);

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
            var user = this._tarczynewsUserRepository.ReadCurrent();
            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                TempData["Error"] = "Unauthorized access. Try to log in again";

                return RedirectToAction("Index", "Home");
            }
            var storedCap = _tarczynCapRepository.ReadTarczynCapByNumberAndOwnerUsername(tarczynCap.Number, user.UserName);

            if(storedCap != null)
            {
                TempData["Error"] = "You already have cap with this number";

                return View(tarczynCap);
            }

            tarczynCap.Owner = user;
            
            if(user.TarczynCaps != null)
            {
                user.TarczynCaps.Add(tarczynCap);
            }
            else
            {
                user.TarczynCaps = new List<TarczynCap>() { tarczynCap };
            }

            _tarczynCapRepository.Create(tarczynCap);
            _tarczynCapRepository.Save();

            _tarczynewsUserRepository.Update(user);
            _tarczynewsUserRepository.Save();

            TempData["Success"] = $"Cap {tarczynCap.Number} was created successfully";

            return RedirectToAction(nameof(Index));
        }

        // GET: CapsController/Edit/5
        public ActionResult Edit(int number)
        {
            var cap = _tarczynCapRepository.ReadTarczynCapByNumberAndOwnerUsername(number, _tarczynewsUserRepository.ReadCurrent().UserName);

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
            var storedCap = _tarczynCapRepository.ReadTarczynCapByNumberAndOwnerUsername(tarczynCap.Number, _tarczynewsUserRepository.ReadCurrent().UserName);

            if(storedCap == null)
            {
                TempData["Error"] = "There was an error while trying to find this cap";
            }
            else
            {
                if (storedCap.Number != tarczynCap.Number)
                {
                    var storedCapWithNumber = _tarczynCapRepository.ReadTarczynCapByNumberAndOwnerUsername(tarczynCap.Number, _tarczynewsUserRepository.ReadCurrent().UserName);

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
            var cap = _tarczynCapRepository.ReadTarczynCapByNumberAndOwnerUsername(number, _tarczynewsUserRepository.ReadCurrent().UserName);

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
            if (cap != null && _tarczynewsUserRepository.ReadCurrent().Id != (cap.Owner?.Id ?? ""))
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
