using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;


namespace TestCase.WebUI.Controllers
{
    public class _UserRelationController : Controller
    {
        // GET: /<controller>/
        UserrelationService relatonService = new UserrelationService();
        UserService userService = new UserService();
        EmployService employService = new EmployService();
        ProjectService projectService = new ProjectService();
        public IActionResult Index(Userrelation relation)
        {
            List<Userrelation> relations = null;
            if (relation.Name == null)
            {
                relations = relatonService.GetAll();
            }
            else
            {
                relations = relatonService.Query(relation);
            }
            ViewData["relations"] = relations;
            return View();
        }

        public IActionResult Detail(Userrelation relation)
        {
            User user = new User
            {
                relation = relatonService.ShowDetail(relation.Uid),
                detail = userService.ShowDetail(relation.Uid),
            };
            return View(user);
        }

        public IActionResult Create(Userdetail detail,Userrelation relation,Employ employ )
        {
            int count = 0;
            count = userService.Create(detail);
            if (count > 0) {
                relation.Uid = count;
                relation.Name = detail.Uname;
                relation.Ename = employService.ShowDetail(relation.Eid).Ename;
                relation.Proname = projectService.ShowDetail((int)relation.Proid).Proname;
                relatonService.Create(relation);
            }
            return Redirect(Url.Action("Index", "_Userrelation"));
            //else 
        }

        public IActionResult Del(Userrelation relation)
        {
            var count = userService.Del((int)relation.Uid);
            if (count > 0)
            {
                count = relatonService.Del((int)relation.Uid);
            }
            if (count == 0) {
                string errormsg = "删除失败";
                return View(errormsg);
            }
            return Redirect(Url.Action("Index", "_Userrelation"));
        }
    //更新

}
}
