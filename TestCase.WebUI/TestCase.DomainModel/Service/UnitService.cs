using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class UnitService
    {
        public List<Unit> GetAll()
        {
            List<Unit> units = null;
            using (var dbContext = new CasemanaContext())
            {
                units = dbContext.Unit.ToList();
            }
            return units;
        }
        public List<Unit> Query(int proid,string unname)
        {
            List<Unit> units = null;
            using (var dbContext = new CasemanaContext())
            {
                if (proid==0) {
                    units = dbContext.Unit.Where(x => x.UnName.Contains(unname) ).ToList();
                }
                else { 
                units = dbContext.Unit.Where(x => x.Proid == proid && x.UnName.Contains(unname)).ToList();
                }
            }
            return units;
        }
        public List<Unit> QueryByPid(int pid)
        {
            List<Unit> units = null;
            using (var dbContext = new CasemanaContext())
            {
                units = dbContext.Unit.Where(x => x.Pid == pid).ToList();
            }
            return units;
        }
        
        public List<Unit> QueryByProid(int proid)
        {
            List<Unit> units = null;
            using (var dbContext = new CasemanaContext())
            {
                units = dbContext.Unit.Where(x => x.Proid == proid).ToList();
            }
            return units;
        }

        public Unit ShowDetail(int unid)
        {
            var unit = new Unit();
            using (var dbContext = new CasemanaContext())
            {
                unit = dbContext.Unit.FirstOrDefault(x => x.Unid == unid);
            }
            return unit;
        }

        public int Create(Unit unit)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                dbContext.Unit.Add(unit);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Del(int unid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var Unit = new Unit() { Unid = unid };
                dbContext.Unit.Attach(Unit);
                dbContext.Unit.Remove(Unit);
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
        public int Update(Unit unit)
        { 
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var x = dbContext.Unit.FirstOrDefault(u => u.Unid == unit.Unid);
                foreach (PropertyInfo info in typeof(Unit).GetProperties())
                {
                    PropertyInfo pro = typeof(Unit).GetProperty(info.Name);
                    if (pro != null)
                        info.SetValue(x, pro.GetValue(unit));
                }
                dbContext.Unit.Update(x);
                count = dbContext.SaveChanges();
            }
            return (int)unit.Unid;
        }
    }
}
