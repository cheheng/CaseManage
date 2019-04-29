using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.Infrastructure.Data;
using TestCase.DomainModel.Service;
namespace TestCase.WebUI.Controllers
{
    public class _CaseDetailController:Controller
    {
        CasedetailService detailService = new CasedetailService();
        public IActionResult Index(Casedetail casedetail)
        {
            List<Casedetail> details = null;
            if (casedetail.Cid == null)
            {
                details = detailService.GetAll();
            }
            else
            {
                details = detailService.Query(casedetail);
            }
            return View();
        }

        public IActionResult Detail(Casedetail casedetail)
        {
            casedetail = detailService.ShowDetail(casedetail);
            return View(casedetail);
        }

        public IActionResult Create(Casedetail casedetail)
        {
            int count = 0;
            count = detailService.Create(casedetail);
            //if(count>0)
            return Redirect(Url.Action("Index", "_Casedetail"));
            //else 
        }

        public IActionResult Del(Casedetail casedetail)
        {
            var count = detailService.Del(casedetail.Id);
            return Redirect(Url.Action("Index", "_Casedetail"));
        }

        //更新

    }
}
