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
        public IActionResult Index(String pname,String pstorage)
        {
            var planService = new PlanService();
            List<Plan> plans = null;
            if (pname == null)
            {
                plans = planService.GetAll();
            }
            else {
                plans = planService.GetThePlans(pname);
            }
            ViewData["plans"] = plans;
            return View();
        }

        public IActionResult Detail(int pid)
        {
            var planSerVice = new PlanService();
            var plan = planSerVice.Show(pid);
            return View(plan);
        }

        public IActionResult Update(Plan plan)
        {
            var planSerVice = new PlanService();
            var id = planSerVice.Update(plan);
            return Redirect(Url.Action("Detail","_Plan")+ $"?pid={id}");
        }
        public IActionResult AddPlan(Plan plan)
        {
            var planSerVice = new PlanService();
            var count = planSerVice.Create( plan.Pname, plan.PStorage);
            return Redirect(Url.Action("Index", "_Plan"));
        }

        public IActionResult Del(Plan plan)
        {
            var planSerVice = new PlanService();
            var count = planSerVice.Del(plan.Pid);
            return Redirect(Url.Action("Index", "_Plan"));
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
