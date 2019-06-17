using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.DomainModel.Service;
using TestCase.Infrastructure.Data;
using Newtonsoft.Json;

namespace TestCase.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        UserService userService = new UserService();
       
        static String errorMsg;
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            ViewData["errorMsg"] = errorMsg;
            errorMsg = null;
            return View();
        }

        public IActionResult Login(Userdetail tologin)
        {
            if (tologin == null)
            {
              errorMsg = "用户名或密码不能为空";
              return Redirect(Url.Action("Index", "Home"));
            }
            var model = userService.ShowDetail(tologin.Uid);
            if (model == null || model.Passwod != tologin.Passwod)
            {
                //ViewData["errorMsg"] = "showErrorMsg(\'用户名或密码错误！\');";
                errorMsg = "用户名或密码错误";
                return Redirect(Url.Action("Index", "Home"));
            }
            model.Passwod = null;
            UserrelationService relationService = new UserrelationService();
            var relation = relationService.ShowDetail(tologin.Uid);
            var user = new User() {
                detail = model,
                relation=relation
            };
            string json = JsonConvert.SerializeObject(user);
            this.Response.Cookies.Append("user", json);
            return Redirect(Url.Action("Privacy", "Home") );
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
