using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;


namespace TestCase.WebUI.Controllers
{
    public class _ProjectController : Controller
    {
        // GET: /<controller>/
        ProjectService projectService = new ProjectService();
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
            project = projectService.ShowDetail(project);
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
            return Redirect(Url.Action("Index", "_Project"));
        }

        //更新


    }
}
