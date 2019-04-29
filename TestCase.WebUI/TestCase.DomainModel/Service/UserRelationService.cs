using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class UserrelationService
    {
        public List<Userrelation> GetAll()
        {
            List<Userrelation> relations = null;
            using (var dbContext = new casemanaContext())
            {
                relations = dbContext.Userrelation.ToList();
            }
            return relations;
        }
        public List<Userrelation> Query(Userrelation relation)
        {
            List<Userrelation> relations = null;
            using (var dbContext = new casemanaContext())
            {
                relations = dbContext.Userrelation.Where(x => x.Urid == relation.Urid).ToList();
            }
            return relations;
        }

        public Userrelation ShowDetail(Userrelation relation)
        {
            using (var dbContext = new casemanaContext())
            {
                relation = dbContext.Userrelation.FirstOrDefault(x => x.Urid == relation.Urid);
            }
            return relation;
        }

        public int Create(Userrelation relation)
        {
            int count = 0;
            var newrelation = new Userrelation()
            {
                Eid = relation.Eid,
                Pid = relation.Pid,
                Proid = relation.Proid,
                Unid = relation.Unid,
                Uid = relation.Uid,
            };
            using (var dbContext = new casemanaContext())
            {
                dbContext.Userrelation.Add(newrelation);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Del(int proid)
        {
            int count = 0;
            using (var dbContext = new casemanaContext())
            {
                var relation = new Userrelation() { Proid = proid };
                dbContext.Userrelation.Attach(relation);
                dbContext.Userrelation.Remove(relation);
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
