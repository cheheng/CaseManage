using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;
using TestCase.WebUI.Models;

namespace TestCase.WebUI.Controllers
{
    public class _PlanController : Controller
    {
        public IActionResult Index()
        {
            var planService = new PlanService();
            var plans = planService.GetAll();
            ViewData["plans"] = plans;
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
