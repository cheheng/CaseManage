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
        CasedetailService detailservice = new CasedetailService();
        UserService userService = new UserService();
        public IActionResult Index(Thecase caselist)
        {
            List<Thecase> cases = null;
            if (caselist.Cid == 0)
            {
                cases = caseService.GetAll();
            }
            else
            {
                cases = caseService.Query(caselist);
            }
            ViewData["cases"] = cases;
            return View();
            }

     
        public IActionResult Detail(ForCase forcase)
        {
            var thecase = caseService.ShowDetail(forcase.Cid);
            var casedetail = detailservice.ShowDetail(forcase.Cid);
            forcase.Ctitle = thecase.Ctitle;
            forcase.Detail = casedetail.Detail;
            forcase.Proid = thecase.Proid;
            forcase.Pid = thecase.Pid;
            forcase.Unid = thecase.Unid;
            forcase.Uid = thecase.Uid;
            forcase.Uid2 = casedetail.Uid;
            forcase.State = thecase.State;
            forcase.Name = userService.ShowDetail(forcase.Uid).Uname;
            forcase.Toname = userService.ShowDetail(forcase.Uid2).Uname;
            forcase.Prior = casedetail.Prior;
            forcase.Detail = casedetail.Detail;
            forcase.Previous = casedetail.Previous;
            return View(forcase);
        }
        

        public IActionResult Create(ForCase forCase)
        {
            int count;
            var thecase = new Thecase()
            {
                Uid = forCase.Uid,
                Pid = forCase.Pid,
                Unid = forCase.Unid,
                Proid = forCase.Proid,
                Ctitle = forCase.Ctitle,
                //Name = userService.ShowDetail(forCase.Uid).Uname,
                State = forCase.State,
                //Toname = userService.ShowDetail(forCase.Uid2).Uname,
            };
            count = caseService.Create(thecase);
            if (count > 0)
            {
                var casedetail = new Casedetail()
                {
                    Cid = count,
                    Uid = forCase.Uid2,
                    ModifyDate = DateTime.Now,
                    Prior = forCase.Prior,
                    Detail = forCase.Detail,
                    Previous=forCase.Previous,
                };
                detailservice.Create(casedetail);
            }
            //if(count>0)
            return Redirect(Url.Action("Index", "_Case"));
            //else 
        }

        public IActionResult Del(ForCase forCase)
        {
            var count = caseService.Del(forCase.Cid);
            if (count > 0)
            {
                detailservice.Del(forCase.Cid);
            }
            return Redirect(Url.Action("Index", "_Thecase"));
        }

        //更新
        //public IActionResult Update(Plan plan)
        //{
        //    var planSerVice = new PlanService();
        //    var id = planSerVice.Update(plan);
        //    return Redirect(Url.Action("Detail", "_Plan") + $"?pid={id}");
        //}
        //public IActionResult Update(ForCase forCase)
        //{
        //    int count = 0;
        //    var thecase = new Thecase()
        //    {
        //        Pid = forCase.Pid,
        //        Unid = forCase.Unid,
        //        Proid = forCase.Proid,
        //        Ctitle = forCase.Ctitle,
        //        State = forCase.State,
        //        Toname = forCase.Toname,
        //    };
        //    count = caseservice.Create(thecase);
        //    if (count > 0)
        //    {
        //        var casedetail = new Casedetail()
        //        {
        //            Uid = forCase.Uid2,
        //            //ModifyDate = DateTime.Now,
        //            Prior = forCase.Prior,
        //            Detail = forCase.Detail,
        //Previous=forCase.Previous,
        //        };
        //        detailservice.Create(casedetail);
        //    }
        //    return Redirect(Url.Action("Detail","_Case")+ $"?cid={id}");
        //}

    }
}
