using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE.Domain.Interfaces.Manager;
using SE.Web.Infrastructure;
using SE.Web.ViewModels;
using Competition = SE.Web.Models.Competition;

namespace SE.Web.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ICompetitionManager _manager;
        private readonly IEventManager _eventManager;

        public CompetitionController(ICompetitionManager manager, IEventManager eventManager)
        {
            _manager = manager;
            _eventManager = eventManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var competitionList = _manager.GetAll();
            var modelList = ServicesAutoMapperConfig.Mapped.Map<List<Competition>>(competitionList);
            return View(modelList);
        }

        [HttpPost]
        public IActionResult Index(List<Competition> competitions)
        {
            for (int i = 0; i < competitions.Count; i++)
            {
                if (competitions[i].isSelected)
                {
                    var e = _manager.Get((competitions[i].CompetitionID));

                    if (e != null)
                        _manager.Delete(e);
                }
            }
            return RedirectToAction("Index", "Competition");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Events = new SelectList(_eventManager.GetAll(), "EventID", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Competition competition)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Create(ServicesAutoMapperConfig.Mapped.Map<DataTransfer.Competition>(competition));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(competition);
        }

        [HttpGet]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return View();
            }

            var e = _manager.Get(id.Value);
            var _competition = ServicesAutoMapperConfig.Mapped.Map<Models.Competition>(e);
            return View(_competition);
        }



        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View();
            }
            var e = _manager.Get(id.Value);
            var _competition = ServicesAutoMapperConfig.Mapped.Map<Models.Competition>(e);
            return View(_competition);
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
            var e = _manager.Get(id.Value);
            var _competition = ServicesAutoMapperConfig.Mapped.Map<Models.Competition>(e);
            return View(_competition);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Competition e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Update(ServicesAutoMapperConfig.Mapped.Map<DataTransfer.Competition>(e));
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var e = _manager.Get(id);
                _manager.Delete(e);
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}