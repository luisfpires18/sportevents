using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tinc.Domain.Interfaces.Manager;
using tinc.Web.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace tinc.Web.Controllers
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
            var modelList = ServicesAutoMapperConfig.Mapped.Map<List<Models.Sport>>(sportList);
            return View(modelList);
        }
    }
}
