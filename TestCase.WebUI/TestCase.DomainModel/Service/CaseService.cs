using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;
using System.Reflection;

namespace TestCase.DomainModel.Service
{
    public class CaseService
    {
        #region Action
        /// <summary>
        /// 获取用例列表
        /// </summary>
        /// <returns></returns>
        public List<Thecase> GetAll()
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.ToList();
            }
            return thecases;
        }

        public List<Thecase> Query(int proid,Thecase thecase)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {

                //if (thecase.Proid != null)
                //{
                //    thecases = dbContext.Thecase.Where(x => x.Proid == thecase.Proid).ToList();
                //}
                //else if (thecase.Pid != null)
                //{
                //    thecases = dbContext.Thecase.Where(x => x.Pid == thecase.Pid).ToList();
                //}
                //else if (thecase.Unid != null)
                //{
                //    thecases = dbContext.Thecase.Where(x => x.Unid == thecase.Unid).ToList();
                //}
                //else

                if (proid == 0)
                {
                    thecases = dbContext.Thecase.Where(x => x.Ctitle.Contains( thecase.Ctitle)).ToList();
                }
                else
                {
                    thecases = dbContext.Thecase.Where(x => x.Ctitle.Contains(thecase.Ctitle) && x.Proid==proid).ToList();
                }
            }
            return thecases;
        }

        public List<Thecase> QueryByProid(int proid)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.Where(x =>  x.Proid == proid).ToList();
            }
            return thecases;
        }
        public List<Thecase> QueryByPid(int pid)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.Where(x => x.Pid == pid).ToList();
            }
            return thecases;
        }
        public List<Thecase> QueryByState(String state)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.Where(x => x.State== state).ToList();
            }
            return thecases;
        }
        public List<Thecase> QueryByName(String name)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.Where(x => x.Name == name).ToList();
            }
            return thecases;
        }

        public List<Thecase> QueryByToName(String name)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.Where(x => x.Toname== name).ToList();
            }
            return thecases;
        }
        public List<Thecase> QueryByUnid(int unid)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                thecases = dbContext.Thecase.Where(x => x.Unid == unid).ToList();
            }
            return thecases;
        }
        public Thecase ShowDetail(int cid)
        {
            Thecase thecase = null;
            using (var dbContext = new CasemanaContext())
            {
                thecase = dbContext.Thecase.FirstOrDefault(x => x.Cid == cid);
            }
            return thecase;
        }

        public int Create(Thecase thecase)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                dbContext.Thecase.Add(thecase);
                count = dbContext.SaveChanges();
            }
            if (count == 0) { }
            return thecase.Cid;
        }

        public int Del(int cid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var thecase = new Thecase() { Cid = cid };
                dbContext.Thecase.Attach(thecase);
                dbContext.Thecase.Remove(thecase);
                //将要删除的对象附加到EF容器中
                //context.Users.Attach(user);
                ////Remove()起到了标记当前对象为删除状态，可以删除
                //context.Users.Remove(user);
                //context.SaveChanges();
                //Console.WriteLine("删除成功");
                count = dbContext.SaveChanges();
            }
            return count;
        }

        //更新
        public int Update(Thecase thecase)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var x = dbContext.Thecase.FirstOrDefault(u => u.Cid == thecase.Cid);
                foreach (PropertyInfo info in typeof(Thecase).GetProperties())
                {
                    PropertyInfo pro = typeof(Thecase).GetProperty(info.Name);
                    if (pro != null)
                        info.SetValue(x, pro.GetValue(thecase));
                }
                dbContext.Thecase.Update(x);
                dbContext.SaveChanges();
            }
            return thecase.Cid;
        }

        #endregion
    }
}
