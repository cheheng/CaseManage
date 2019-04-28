using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;

// For more information on enabling MVC for empty units, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCase.WebUI.Controllers
{
    public class _UnitController : Controller
    {
        UnitService unitService = new UnitService();
        // GET: /<controller>/
        public IActionResult Index(Unit unit)
        {
            List<Unit> units = null;
            if (unit.UnName == null)
            {
                units = unitService.GetAll();
            }
            else
            {
                units = unitService.Query(unit);
            }
            return View();
        }

        public IActionResult Detail(Unit unit)
        {
            unit = unitService.ShowDetail(unit);
            return View(unit);
        }

        public IActionResult Create(Unit unit)
        {
            int count = 0;
            count = unitService.Create(unit);
            //if(count>0)
            return Redirect(Url.Action("Index", "_Unit"));
            //else 
        }

        public IActionResult Del(Unit unit)
        {
            var count = unitService.Del(unit.Unid);
            return Redirect(Url.Action("Index", "_Unit"));
        }

        //更新
    }
}
