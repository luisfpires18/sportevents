using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SE.DataTransfer;
using SE.Domain.Interfaces.Manager;
using SE.Web.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SE.Web.Controllers
{
    public partial class SportController : Controller
    {
        private readonly ISportManager _manager;

        public SportController(ISportManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sportList = _manager.GetAll();
            var modelList = ServicesAutoMapperConfig.Mapped.Map<List<Models.Sport>>(sportList);
            return View(modelList);
        }

        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return View();
            }

            Sport sport = _manager.Get(id.Value);
            var sportModel = ServicesAutoMapperConfig.Mapped.Map<Models.Sport>(sport);
            return View(sportModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View();
            }
            Sport sport = _manager.Get(id.Value);
            var sportModel = ServicesAutoMapperConfig.Mapped.Map<Models.Sport>(sport);
            return View(sportModel);
        }

        [HttpGet]
        public ActionResult Delete(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return View();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage =
                    "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Sport sport = _manager.Get(id.Value);
            var sportModel = ServicesAutoMapperConfig.Mapped.Map<Models.Sport>(sport);
            return View(sportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Sport sport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Create(ServicesAutoMapperConfig.Mapped.Map<DataTransfer.Sport>(sport));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(sport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Sport sport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Update(ServicesAutoMapperConfig.Mapped.Map<DataTransfer.Sport>(sport));
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(sport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var sport = _manager.Get(id);
                _manager.Delete(sport);
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new {id = id, saveChangesError = true});
            }
            return RedirectToAction("Index");
        }
    }
}
