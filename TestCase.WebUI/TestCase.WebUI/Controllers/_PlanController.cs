using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;
using TestCase.WebUI.Models;

namespace TestCase.WebUI.Controllers
{
    public class _PlanController : BaseController
    {
        ProjectService projectService = new ProjectService();
        public IActionResult Index(Plan plan)
        {
            var planService = new PlanService();
            List<Plan> plans = null;
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            int proid = (int)loginuser.relation.Proid;
            List<Project> projects = null;
           if (loginuser.relation.Eid == 1)
            {
                projects = projectService.GetAll();
                if (plan.Proid > 0)
                {
                    plans = planService.QueryByProid((int)plan.Proid);
                }
                else if (plan.Pname == null)
                {
                    plans = planService.GetAll();
                }
                else
                {
                    plans = planService.GetPlans( 0,plan.Pname);
                }
            }
           else
            {
                projects = projectService.QueryById(proid);
                if (plan.Pname == null)
                {
                    plans = planService.QueryByProid(proid);
                }
                else
                {
                    plans = planService.GetPlans(proid,plan.Pname);
                }
            }
           
           
            ViewData["projects"] = projects;
            ViewData["plans"] = plans;
            return View();
        }

        public IActionResult Detail(int pid)
        {
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            List<Project> projects = null;
            if (loginuser.relation.Eid == 1)
            {
                projects = projectService.GetAll();
            }
            else
            {
                projects = projectService.QueryById((int)loginuser.relation.Proid);
            }
            ViewData["projects"] = projects;
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
            plan.Proname = projectService.ShowDetail((int)plan.Proid).Proname;
            var count = planSerVice.Create( plan);
            return Redirect(Url.Action("Index", "_Plan"));
        }

        public IActionResult Del(Plan plan)
        {
            var planSerVice = new PlanService();
            UnitService unitService = new UnitService();
            CaseService caseService = new CaseService();
            CasedetailService detailservice = new CasedetailService();
            var units = unitService.QueryByPid(plan.Pid);
            foreach (Unit u in units)
            {
                unitService.Del(u.Unid);
            }
            var cases = caseService.QueryByPid(plan.Pid);
            foreach (Thecase c in cases)
            {
                caseService.Del(c.Cid);
                detailservice.Del(c.Cid);
            }

            var count = planSerVice.Del(plan.Pid);
            return Redirect(Url.Action("Index", "_Plan"));
        }


    }
}
