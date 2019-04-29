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
            return View();
        }

        public IActionResult Detail(Userrelation relation)
        {
            relation = relatonService.ShowDetail(relation);
            return View(relation);
        }

        public IActionResult Create(Userrelation relation)
        {
            int count = 0;
            count = relatonService.Create(relation);
            //if(count>0)
            return Redirect(Url.Action("Index", "_Userrelation"));
            //else 
        }

        public IActionResult Del(Userrelation relation)
        {
            var count = relatonService.Del(relation.Urid);
            return Redirect(Url.Action("Index", "_Userrelation"));
        }
    //更新
}
}
