using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.Infrastructure.Data;
using TestCase.DomainModel.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCase.WebUI.Controllers
{
    public class _CaseController : Controller
    {
        /// <summary>
        /// 加载用户列表和页面布局
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        public IActionResult Index()
        {
            var caseService = new CaseService();
            var cases = caseService.GetAll();
            ViewData["cases"] = cases;
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

    }
}
