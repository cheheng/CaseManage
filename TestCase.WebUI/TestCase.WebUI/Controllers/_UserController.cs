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
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index(Userdetail user)
        {
            user = userService.ShowDetail(user.Uid);
            return View(user);
        }
       
        
        public IActionResult ForgetPsw()
        {
            return View();
        }
        //更新
    }
}
