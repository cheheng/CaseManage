using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;

namespace TestCase.WebUI.Controllers
{
    public class _UnitController : BaseController
    {
        UnitService unitService = new UnitService();
        // GET: /<controller>/
        public IActionResult Index(Unit unit)
        {
            var planService = new PlanService();
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            List<Plan> plans = null;
            List<Unit> units = null;
            if (loginuser.relation.Eid == 1)
            {
                plans = planService.GetAll();
                if (unit.Proid > 0)
                {
                    units = unitService.QueryByProid((int)unit.Proid);
                }
                else if (unit.Pid > 0)
                {
                    units = unitService.QueryByPid((int)unit.Pid);
                }
                else  if (unit.UnName == null)
                {
                    units = unitService.GetAll();
                }
                else
                {
                    units = unitService.Query(0, unit.UnName);
                }
            }
            else
            {
                int proid = (int)loginuser.relation.Proid;
                plans = planService.QueryByProid(proid);
                 if (unit.Pid > 0)
                {
                    units = unitService.QueryByPid((int)unit.Pid);
                }
                else if (unit.UnName == null)
                {
                    units = unitService.QueryByProid(proid);
                }
                else {
                    units = unitService.Query(proid, unit.UnName);
                }
            }
            ViewData["units"] = units;
            ViewData["plans"] = plans;
            return View();
        }

        public IActionResult Detail(Unit unit)
        {
            var planService = new PlanService();
            var projectService = new ProjectService();
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            List<Plan> plans = null;
            plans = planService.QueryByProid((int)loginuser.relation.Proid);
            unit = unitService.ShowDetail(unit.Unid);
            unit.Proname =projectService.ShowDetail((int)unit.Proid).Proname;
            ViewData["plans"] = plans;
            return View(unit);
        }

        public IActionResult Create(Unit unit)
        {
            int count = 0;
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            unit.Proid = loginuser.relation.Proid;
            unit.Uid = loginuser.detail.Uid;
            PlanService planService = new PlanService();
            unit.Pname = planService.Show((int)unit.Pid).Pname;
            count = unitService.Create(unit);
            //if(count>0)
            return Redirect(Url.Action("Index", "_Unit"));
            //else 
        }

        public IActionResult Del(Unit unit)
        {
            var count = unitService.Del(unit.Unid);
            CaseService caseService = new CaseService();
            CasedetailService detailservice = new CasedetailService();
            var cases = caseService.QueryByUnid(unit.Unid);
            foreach (Thecase c in cases)
            {
                caseService.Del(c.Cid);
                detailservice.Del(c.Cid);
            }
            return Redirect(Url.Action("Index", "_Unit"));
        }

        //更新
        public IActionResult Update(Unit unit)
        {
            var projectService = new ProjectService();
            unit.Proname = projectService.ShowDetail((int)unit.Proid).Proname;
            var planService = new PlanService();
            unit.Pname= planService.Show((int)unit.Pid).Pname;
            var id = unitService.Update(unit);
            return Redirect(Url.Action("Detail", "_Unit") + $"?unid={id}");
        }
    }
}
