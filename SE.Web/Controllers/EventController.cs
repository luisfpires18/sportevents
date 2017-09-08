using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE.Domain.Interfaces.Manager;
using SE.Web.Infrastructure;
using SE.Web.ViewModels;
using Event = SE.Web.Models.Event;

namespace SE.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventManager _manager;
        private readonly ISportManager _sportManager;

        public EventController(IEventManager manager, ISportManager sportManager)
        {
            _manager = manager;
            _sportManager = sportManager;
        }

        [HttpGet]
        public IActionResult Index(int? id, int? competitionID)
        {
            var viewModel = new EventData
            {
                Events = ServicesAutoMapperConfig.Mapped.Map<List<Event>>(_manager.GetAll())
            };


            //if (id != null)
            //{
            //    ViewBag.EventoID = id.Value;

            //    viewModel.Provas = viewModel.Eventos
            //        .Single(e => e.ID == id.Value).Provas;
            //}
            //if (competitionID != null)
            //{
            //    ViewBag.ProvaID = competitionID.Value;
            //    viewModel.Categorias = viewModel.Provas
            //        .Single(p => p.ID == competitionID.Value).Categorias;
            //}

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(List<Event> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].isSelected)
                {
                    var e = _manager.Get((events[i].EventID));

                    if (e != null)
                        _manager.Delete(e);
                }
            }
            return RedirectToAction("Index", "Event");
        }

        [HttpGet]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return View();
            }

            var e = _manager.Get(id.Value);
            var _event = ServicesAutoMapperConfig.Mapped.Map<Models.Event>(e);
            return View(_event);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Sports = new SelectList(_sportManager.GetAll(), "SportID", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View();
            }
            var e = _manager.Get(id.Value);
            var _event = ServicesAutoMapperConfig.Mapped.Map<Models.Event>(e);
            return View(_event);
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
            var _event = ServicesAutoMapperConfig.Mapped.Map<Models.Event>(e);
            return View(_event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Create(ServicesAutoMapperConfig.Mapped.Map<DataTransfer.Event>(e));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Update(ServicesAutoMapperConfig.Mapped.Map<DataTransfer.Event>(e));
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