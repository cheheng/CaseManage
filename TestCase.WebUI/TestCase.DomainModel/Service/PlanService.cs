using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCase.Infrastructure.Data;

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
            using (var dbContet = new casemanaContext())
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
        public int Add(string pname, string pstorage)
        {
            int count = 0;
            var plan = new Plan()
            {
                //Proid = proid,
                Pname = pname,
                PStorage = pstorage,
            };
            using (var dbContext = new casemanaContext())
            {
                dbContext.Plan.Add(plan);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Create(string pname, string pstorage)
        {
            int count = 0;
            var plan = new Plan()
            {
                //Proid = proid,
                Pname = pname,
                PStorage = pstorage,
            };
            using (var dbContext = new casemanaContext())
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
            using (var dbContext = new casemanaContext())
            {
                var plan = new Plan() { Pid = pid };
                dbContext.Plan.Attach(plan);
                dbContext.Plan.Remove(plan);
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
        /// <summary>
        /// 展示详情
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Plan> Show(int pid)
        {
            List<Plan> plan = null;
            using (var dbContext = new casemanaContext())
            {
                plan = dbContext.Plan.Where(x => x.Pid == pid).ToList();
                //var s = context.Users.Where(u => u.Name == "Kim").Select(u => u)
            }
            return plan;
        }

        public List<Plan> GetThePlans(String pname)
        {
            List<Plan> plans = null;
            using (var daContext = new casemanaContext())
            {
                plans = daContext.Plan.Where(x => x.Pname == pname).ToList();
            }
            return plans;
        }
        #endregion


    }
}
