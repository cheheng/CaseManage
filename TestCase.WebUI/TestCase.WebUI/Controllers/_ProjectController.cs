using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;


namespace TestCase.WebUI.Controllers
{
    public class _ProjectController : BaseController
    {
        // GET: /<controller>/
        ProjectService projectService = new ProjectService();
        PlanService planService = new PlanService();
        UnitService unitService = new UnitService();
        CaseService caseService = new CaseService();
        CasedetailService detailservice = new CasedetailService();
        public IActionResult Index(Project project)
        {

            List<Project> projects = null;
            if (project.Proname == null)
            {
                projects = projectService.GetAll();
            }
            else
            {
                projects = projectService.Query(project);
            }
            ViewData["projects"] = projects;
            return View();
        }

        public IActionResult Detail(Project project)
        {
            project = projectService.ShowDetail(project.Proid);
            return View(project);
        }

        public IActionResult Create(Project project)
        {
            int count = 0;
            count = projectService.Create(project);
            //if(count>0)
            return Redirect(Url.Action("Index", "_Project"));
            //else 
        }

        public IActionResult Del(Project project)
        {
            var count = projectService.Del(project.Proid);
            var plans = planService.QueryByProid(project.Proid);
            foreach (Plan x in plans) {
                planService.Del(x.Pid);
            }
            var units = unitService.QueryByProid(project.Proid);
            foreach (Unit u in units) {
                unitService.Del(u.Unid);
            }
            var cases = caseService.QueryByProid(project.Proid);
            foreach (Thecase c in cases) {
                caseService.Del(c.Cid);
                detailservice.Del(c.Cid);
            }
            return Redirect(Url.Action("Index", "_Project"));
        }

        //更新
        public IActionResult Update(Project project)
        {
            var id = projectService.Update(project);
            return Redirect(Url.Action("Detail", "_Project") + $"?proid={id}");
        }

    }
}
