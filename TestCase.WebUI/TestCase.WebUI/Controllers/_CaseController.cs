using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCase.Infrastructure.Data;
using TestCase.DomainModel.Service;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using OfficeOpenXml;


namespace TestCase.WebUI.Controllers
{
    public class _CaseController : BaseController
    {
        /// <summary>
        /// 加载列表和页面布局
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        CaseService caseService = new CaseService();
        UnitService unitService = new UnitService();
        PlanService planService = new PlanService();
        ProjectService projectService = new ProjectService();
        CasedetailService detailservice = new CasedetailService();
        UserrelationService relationService = new UserrelationService();
        public IActionResult Index(Thecase caselist)
        {
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            List<Plan> plans = null;
            List<Unit> units = null;
            List<Project> projects = null;
            List<Userrelation> relations = null;
            List<Thecase> cases = null;
            if (loginuser.relation.Eid == 1)
            {
                plans = planService.GetAll();
                projects = projectService.GetAll();
                units = unitService.GetAll();
                relations = relationService.GetAll();
                if (caselist.Proid>0) {
                    cases = caseService.QueryByProid((int)caselist.Proid);
                }
                else if (caselist.Pid > 0)
                {
                    cases = caseService.QueryByPid((int)caselist.Pid);
                }
                else if (caselist.Unid > 0)
                {
                    cases = caseService.QueryByUnid((int)caselist.Unid);
                }
                else if (caselist.State !=null)
                {
                    cases = caseService.QueryByState(caselist.State);
                }
                else if (caselist.Name!=null)
                {
                    cases = caseService.QueryByName(loginuser.relation.Name);
                }
                else if (caselist.Toname != null)
                {
                    cases = caseService.QueryByToName(loginuser.relation.Name);
                }
                else if (caselist.State != null)
                {
                    cases = caseService.QueryByState(caselist.State);
                }
                else if (caselist.Ctitle == null)
                {
                    cases = caseService.GetAll();
                }
                else
                {
                    cases = caseService.Query(0, caselist);
                }
            }
            else
            {
                int proid = (int)loginuser.relation.Proid;
                projects = projectService.QueryById(proid);
                plans = planService.QueryByProid(proid);
                units = unitService.QueryByProid(proid);
                relations = relationService.QueryByProid(proid);
                if (caselist.Pid > 0)
                {
                    cases = caseService.QueryByPid((int)caselist.Pid);
                }
                else if (caselist.Unid > 0)
                {
                    cases = caseService.QueryByUnid((int)caselist.Unid);
                }
                else if (caselist.State != null)
                {
                    cases = caseService.QueryByState(caselist.State);
                }
                else if (caselist.Name != null)
                {
                    cases = caseService.QueryByName(loginuser.relation.Name);
                }
                else if (caselist.Toname != null)
                {
                    cases = caseService.QueryByToName(loginuser.relation.Name);
                }
                else if (caselist.Ctitle == null)
                {
                    cases = caseService.QueryByProid(proid);
                }
                else
                {
                    cases = caseService.Query(proid, caselist);
                }
            }
            ViewData["projects"] = projects;
            ViewData["plans"] = plans;
            ViewData["units"] = units;
            ViewData["relations"] = relations;
            ViewData["cases"] = cases;
            return View();
            }

     
        public IActionResult Detail(ForCase forcase)
        {
            var json = HttpContext.Request.Cookies["user"];
            User loginuser = JsonConvert.DeserializeObject<User>(json);
            List<Plan> plans = null;
            List<Unit> units = null;
            List<Project> projects = null;
            List<Userrelation> relations = null;
            if (loginuser.relation.Eid == 1)
            {
                plans = planService.GetAll();
                projects = projectService.GetAll();
                units = unitService.GetAll();
                relations = relationService.GetAll();
            }
            else
            {
                int proid = (int)loginuser.relation.Proid;
                projects = projectService.QueryById(proid);
                plans = planService.QueryByProid(proid);
                units = unitService.QueryByProid(proid);
                relations = relationService.QueryByProid(proid);
            }
            ViewData["projects"] = projects;
            ViewData["plans"] = plans;
            ViewData["units"] = units;
            ViewData["relations"] = relations;
            //
            var thecase = caseService.ShowDetail(forcase.Cid);
            var casedetail = detailservice.ShowDetail(forcase.Cid);
            forcase.Ctitle = thecase.Ctitle;
            forcase.Detail = casedetail.Detail;
            forcase.Proid = thecase.Proid;
            forcase.Proname = projectService.ShowDetail((int)thecase.Proid).Proname;
            forcase.Pid = thecase.Pid;
            if (thecase.Pid != null)
            {
                forcase.Pname = planService.Show((int)thecase.Pid).Pname;
            }
            forcase.Unid = thecase.Unid;
            if (thecase.Unid != null) {
                forcase.UnName = unitService.ShowDetail((int)thecase.Unid).UnName;
            }
            forcase.Uid = thecase.Uid;
            forcase.Uid2 = casedetail.Uid;
            forcase.State = thecase.State;
            forcase.Name = thecase.Name;
            forcase.Toname = thecase.Toname;
            forcase.Prior = casedetail.Prior;
            forcase.Detail = casedetail.Detail;
            forcase.Previous = casedetail.Previous;
            forcase.Result = casedetail.Result;
            forcase.ModifyDate = casedetail.ModifyDate;
            return View(forcase);
        }
        

        public IActionResult Create(ForCase forCase)
        {
            int count=0;
            var casedetail = new Casedetail()
            {
                Uid = forCase.Uid2,
                ModifyDate = DateTime.Now,
                Prior = forCase.Prior,
                Detail = forCase.Detail,
                Previous = forCase.Previous,
            };
          var  cid = detailservice.Create(casedetail);
            if (cid > 0)
            {
                var json = HttpContext.Request.Cookies["user"];
                User loginuser = JsonConvert.DeserializeObject<User>(json);
                var thecase = new Thecase()
                {
                    Cid = cid,
                    Uid = loginuser.detail.Uid,
                    Pid = forCase.Pid,
                    Unid = forCase.Unid,
                    Proid = loginuser.relation.Proid,
                    Ctitle = forCase.Ctitle,
                    Name = loginuser.detail.Uname,
                    State = "enable",
                    Toname = relationService.ShowDetail(forCase.Uid2).Name,
                };
                count = caseService.Create(thecase);
                if (count == 0)
                {
                    detailservice.Del(cid);
                }
            }
            return Redirect(Url.Action("Index", "_Case"));
            //else 
        }
        public IActionResult RunCase(ForCase forCase)
        {
            var thecase = caseService.ShowDetail(forCase.Cid);
            var casedetail = detailservice.ShowDetail(forCase.Cid);
            thecase.State = forCase.State;
            casedetail.Result = forCase.Result;
            caseService.Update(thecase);
            detailservice.Update(casedetail);
            return Redirect(Url.Action("Index", "_Case"));
            //else 
        }

        public IActionResult Reset(int cid )
        {
            var thecase = caseService.ShowDetail(cid);
            thecase.State = "enable";
            caseService.Update(thecase);
            return Redirect(Url.Action("Index", "_Case"));
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
        public IActionResult Update(ForCase forCase)
        {
            var casedetail = new Casedetail();
            var thecase = new Thecase();
            foreach (PropertyInfo info in typeof(Thecase).GetProperties())
            {
                PropertyInfo pro = typeof(ForCase).GetProperty(info.Name);
                if (pro != null)
                    info.SetValue(thecase, pro.GetValue(forCase));
            }
            foreach (PropertyInfo info in typeof(Casedetail).GetProperties())
            {
                    PropertyInfo pro = typeof(ForCase).GetProperty(info.Name);
                    if (pro != null)
                        info.SetValue(casedetail, pro.GetValue(forCase));
            }
            thecase.Uid = caseService.ShowDetail(forCase.Cid).Uid;
            thecase.Toname = relationService.ShowDetail(forCase.Uid2).Name;
            casedetail.Uid = forCase.Uid2;
            caseService.Update(thecase);
            detailservice.Update(casedetail);
            return Redirect(Url.Action("Detail", "_Case") + $"?cid={forCase.Cid}");
        }


        //生成报告
        private IHostingEnvironment _hostingEnvironment;
        public _CaseController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }     
        public IActionResult Export(int cid)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName)); using (ExcelPackage package = new ExcelPackage(file))
            {  
                // 添加worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("aspnetcore");
                //添加头
                 worksheet.Cells["A1"].Value = "编号";
                worksheet.Cells["E1"].Value = "是否为空";
                worksheet.Cells["A2"].Value = "标题";
                worksheet.Cells["A3"].Value = "所属项目";
                worksheet.Cells["A4"].Value = "所属计划";
                worksheet.Cells["A5"].Value = "所属集合";
                worksheet.Cells["A6"].Value = "创建者";
                worksheet.Cells["A7"].Value = "指派给";
                worksheet.Cells["A8"].Value = "前置条件";
                worksheet.Cells["A9"].Value = "执行步骤";
                worksheet.Cells["A10"].Value = "实际结果";
                worksheet.Cells["A11"].Value = "状态";
                worksheet.Cells["A12"].Value = "实际结果";
                worksheet.Cells["A13"].Value = "创建时间";
                worksheet.Cells["D14"].Value = "完整性";
                worksheet.Cells["D15"].Value = "是否合格";
                worksheet.Cells["E15"].Value = "合格";
                float percent;
                int count = 12;
                var thecase = caseService.ShowDetail(cid);
                var casedetail = detailservice.ShowDetail(cid);
                //添加值
                  worksheet.Cells["B1"].Value = thecase.Cid;
                  worksheet.Cells["B2"].Value = thecase.Ctitle.ToString();
                worksheet.Cells["B3"].Value = projectService.ShowDetail((int)thecase.Proid).Proname;
                if (thecase.Pid != null)
                {
                    worksheet.Cells["B4"].Value = planService.Show((int)thecase.Pid).Pname.ToString();
                }
                if (thecase.Unid != null)
                {
                    worksheet.Cells["B5"].Value = unitService.ShowDetail((int)thecase.Unid).UnName.ToString();
                }
                  worksheet.Cells["B6"].Value = thecase.Name.ToString();

                  worksheet.Cells["B7"].Value = thecase.Toname.ToString();
                if (casedetail.Previous != null) {
                    worksheet.Cells["B8"].Value = casedetail.Previous;
                }
                if (casedetail.Prior != null)
                {
                    worksheet.Cells["B10"].Value = casedetail.Prior;
                }
                if (casedetail.Detail != null)
                {
                    worksheet.Cells["B9"].Value = casedetail.Detail;
                }
                if (casedetail.Result != null)
                {
                    worksheet.Cells["B12"].Value = casedetail.Result;
                }
                
                worksheet.Cells["B11"].Value = thecase.State.ToString();
                 
                worksheet.Cells["B13"].Value = casedetail.ModifyDate;
                for (int col = 2; col <= 13; col++) {
                    worksheet.Cells[col, 5].Value = "×";
                    if (worksheet.Cells[ col,2].Value == null) {
                        worksheet.Cells[col,5].Value = "√";
                        count--;
                    }
                    
                }
                percent =(float) count/12;
                  worksheet.Cells["E14"].Value = percent;
                  worksheet.Cells["E14"].Style.Font.Bold = true;
                if (percent <= 0.50)
                {
                    worksheet.Cells["E15"].Value = "不合格";
                    worksheet.Cells["D16"].Value = "原因";
                    worksheet.Cells["E16"].Value = "信息填写完整率过低";
                }
                else if (worksheet.Cells[9, 2].Value == null)
                {
                    worksheet.Cells["E15"].Value = "不合格";
                    worksheet.Cells["D16"].Value = "原因";
                    worksheet.Cells["E16"].Value = "没有实现步骤";
                }
                else if (worksheet.Cells[10, 2].Value == null)
                {
                    worksheet.Cells["E15"].Value = "不合格";
                    worksheet.Cells["D16"].Value = "原因";
                    worksheet.Cells["E16"].Value = "没有预期结果";
                }
                else if (worksheet.Cells[11, 2].Value.ToString() != "enable" && worksheet.Cells[12, 2].Value == null)
                {
                    worksheet.Cells["E15"].Value = "不合格";
                    worksheet.Cells["D16"].Value = "原因";
                    worksheet.Cells["E16"].Value = "已执行过却没有执行结果";
                }
                //worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[5, 15],).Columns.AutoFit();//设置单元格宽度为自适应
                package.Save();
            }

            return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
