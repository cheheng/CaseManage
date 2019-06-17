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
    public class _UserController : BaseController
    {
        UserService userService = new UserService();
        //UserrelationService relationService = new UserrelationService();
        // GET: /<controller>/
        public IActionResult Detail()
        {
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            return View(loginuser);
        }
        public IActionResult UpdatePsw()
        {

            return View();
        }
        //更新
        public IActionResult Update(Userdetail detail)
        {
            
            if (userService.ShowDetail(detail.Uid).Uname != detail.Uname)
            {
                var relatonService = new UserrelationService();
                var relation = relatonService.ShowDetail(detail.Uid);
                relation.Name= detail.Uname;
                relatonService.Update(relation);
            }
            var id = userService.Update(detail);
            return Redirect(Url.Action("Detail", "_User") + $"?uid={id}");
        }
    }
}
