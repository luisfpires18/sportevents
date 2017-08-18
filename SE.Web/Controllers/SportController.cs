using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using SE.DataTransfer;
using SE.Domain.Interfaces.Manager;
using SE.Web.Infrastructure;
using Sport = SE.Web.Models.Sport;

namespace SE.Web.Controllers
{
    public class SportController : Controller
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
            var modelList = ServicesAutoMapperConfig.Mapped.Map<List<Sport>>(sportList);
            return View(modelList);
        }

        [HttpPost]
        public IActionResult Index(List<Sport> Sports)
        {
            for (int i = 0; i < Sports.Count; i++)
            {
                if (Sports[i].isSelected)
                {
                    var sport = _manager.Get((Sports[i].SportID));

                    if (sport != null)
                        _manager.Delete(sport);
                }
            }
            return RedirectToAction("Index", "Sport");
        }

        [HttpGet]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return View();
            }

            var sport = _manager.Get(id.Value);
            var sportModel = ServicesAutoMapperConfig.Mapped.Map<Models.Sport>(sport);
            return View(sportModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View();
            }
            var sport = _manager.Get(id.Value);
            var sportModel = ServicesAutoMapperConfig.Mapped.Map<Models.Sport>(sport);
            return View(sportModel);
        }

        [HttpGet]
        public IActionResult Delete(Guid? id, bool? saveChangesError = false)
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
            var sport = _manager.Get(id.Value);
            var sportModel = ServicesAutoMapperConfig.Mapped.Map<Models.Sport>(sport);
            return View(sportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Sport sport)
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
                ModelState.AddModelError("","Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(sport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Sport sport)
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
        public IActionResult Delete(Guid id)
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
