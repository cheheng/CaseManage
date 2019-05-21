using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;


namespace TestCase.WebUI.Controllers
{
    public class _UserController : Controller
    {
        UserService userService = new UserService();
        UserrelationService relationService = new UserrelationService();
        // GET: /<controller>/
        public IActionResult Index(Userdetail user)
        {
            user = userService.ShowDetail(user.Uid);
            return View(user);
        }

        public IActionResult Detail(Userdetail detail)
        {
            User user = new User
            {
                relation = relationService.ShowDetail(detail.Uid),
                detail = userService.ShowDetail(detail.Uid),
            };
            return View(user);
        }
        public IActionResult UpdatePsw()
        {
            return View();
        }
        //更新
        public IActionResult Update(Userdetail detail)
        {
            var id = userService.Update(detail);
            return Redirect(Url.Action("Detail", "_User") + $"?uid={id}");
        }
    }
}
