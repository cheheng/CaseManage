using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class UnitService
    {
        public List<Unit> GetAll()
        {
            List<Unit> units = null;
            using (var dbContext = new casemanaContext())
            {
                units = dbContext.Unit.ToList();
            }
            return units;
        }
        public List<Unit> Query(Unit unit)
        {
            List<Unit> units = null;
            using (var dbContext = new casemanaContext())
            {
                units = dbContext.Unit.Where(x => x.Unid == unit.Unid).ToList();
            }
            return units;
        }

        public Unit ShowDetail(Unit unit)
        {
            using (var dbContext = new casemanaContext())
            {
                unit = dbContext.Unit.FirstOrDefault(x => x.Unid == unit.Unid);
            }
            return unit;
        }

        public int Create(Unit unit)
        {
            int count = 0;
            var newunit = new Unit()
            {
                Unid = unit.Unid,
                UnName = unit.UnName,
                Uid = unit.Uid,
                Pid = unit.Pid,
                Proid = unit.Proid,
                UnStorage = unit.UnStorage,
            };
            using (var dbContext = new casemanaContext())
            {
                dbContext.Unit.Add(newunit);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Del(int proid)
        {
            int count = 0;
            using (var dbContext = new casemanaContext())
            {
                var Unit = new Unit() { Unid = proid };
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
    }
}
