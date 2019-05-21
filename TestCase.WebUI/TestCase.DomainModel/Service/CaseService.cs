﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;

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

        public List<Thecase> Query(Thecase thecase)
        {
            List<Thecase> thecases = null;
            using (var dbContext = new CasemanaContext())
            {
                if (thecase.Proid != null)
                {
                    thecases = dbContext.Thecase.Where(x => x.Proid == thecase.Proid).ToList();
                }
                else if (thecase.Pid != null)
                {
                    thecases = dbContext.Thecase.Where(x => x.Pid == thecase.Pid).ToList();
                }
                else if (thecase.Unid != null)
                {
                    thecases = dbContext.Thecase.Where(x => x.Unid == thecase.Unid).ToList();
                }
                else if (thecase.Ctitle != null)
                {
                    thecases = dbContext.Thecase.Where(x => x.Ctitle == thecase.Ctitle).ToList();
                }
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
                x = thecase;
                dbContext.Thecase.Update(x);
                count = dbContext.SaveChanges();
            }
            if (count > 0) { return thecase.Cid; }
            else return count;
        }

        #endregion


    }
}
