﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;
using System.Reflection;

namespace TestCase.DomainModel.Service
{
    public class PlanService
    {
        #region Action
        /// <summary>
        /// 获取用例列表
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetAll()
        {
            List<Plan> plans = null;
            using (var dbContet = new CasemanaContext())
            {
                plans = dbContet.Plan.ToList();
            }
            return plans;
        }
        /// <summary>
        /// 添加计划
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pstorage"></param>
        /// <returns></returns>
        public int Create(Plan plan)
        {
            int count = 0;
            
            using (var dbContext = new CasemanaContext())
            {
                dbContext.Plan.Add(plan);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int Del(int pid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var plan = new Plan() { Pid = pid };
                dbContext.Plan.Attach(plan);
                dbContext.Plan.Remove(plan);
                //将要删除的对象附加到EF容器中
                //context.Users.Attach(user);
                //Remove()起到了标记当前对象为删除状态，可以删除
                //context.Users.Remove(user);
                //context.SaveChanges();
                //Console.WriteLine("删除成功");
                count = dbContext.SaveChanges();
            }
            return count;
        }
        /// <summary>
        /// 展示详情
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Plan Show(int pid)
        {
            Plan plan = null;
            using (var dbContext = new CasemanaContext())
            {
                plan = dbContext.Plan.FirstOrDefault(x => x.Pid == pid);
            }
            return plan;
        }
        /// <summary>
        /// 按标题查询
        /// </summary>
        /// <param name="pname"></param>
        /// <returns></returns>
        public List<Plan> GetPlans(int proid, String pname)
        {
            List<Plan> plans = null;
            using (var dbContext = new CasemanaContext())
            {
                if (proid == 0)
                {
                    plans = dbContext.Plan.Where(x => x.Pname.Contains(pname)).ToList();
                }
                else {
                    plans = dbContext.Plan.Where(x => x.Pname.Contains( pname) && x.Proid==proid).ToList();
                }
            }
            return plans;
        }
        public List<Plan> QueryByProid(int proid)
        {
            List<Plan> plans = null;
            using (var dbContext = new CasemanaContext())
            {
                plans = dbContext.Plan.Where(x => x.Proid == proid).ToList();
            }
            return plans;
        }
        public int Update(Plan plan)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
              var x= dbContext.Plan.FirstOrDefault(u => u.Pid == plan.Pid);
                foreach (PropertyInfo info in typeof(Plan).GetProperties())
                {
                    PropertyInfo pro = typeof(Plan).GetProperty(info.Name);
                    if (pro != null)
                        info.SetValue(x, pro.GetValue(plan));
                }
                dbContext.Plan.Update(x);
              count= dbContext.SaveChanges();
            }
            return plan.Pid; 
        }
        #endregion
    }
}
