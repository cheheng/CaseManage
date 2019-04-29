using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.Infrastructure.Data;
using TestCase.DomainModel.Service;

namespace TestCase.WebUI.Controllers
{
    public class _CaseController : Controller
    {
        /// <summary>
        /// 加载用户列表和页面布局
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        CaseService caseService = new CaseService();
        public IActionResult Index()
        {
            var cases = caseService.GetAll();
            ViewData["cases"] = cases;
            return View();
        }

        public IActionResult Detail(Thecase thecase)
        {
            thecase = caseService.ShowDetail(thecase);
            return View(thecase);
        }

        public IActionResult Create(Thecase thecase)
        {
            int count = 0;
            count = caseService.Create(thecase);
            //if(count>0)
            return Redirect(Url.Action("Index", "_Thecase"));
            //else 
        }

        public IActionResult Del(Thecase thecase)
        {
            var count = caseService.Del(thecase.Cid);
            return Redirect(Url.Action("Index", "_Thecase"));
        }

        //更新
    }
}
