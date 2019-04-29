using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class CasedetailService
    {
        #region Action
        /// <summary>
        /// 获取用例列表
        /// </summary>
        /// <returns></returns>
        public List<Casedetail> GetAll()
        {
            List<Casedetail> casedetails = null;
            using (var dbContext = new casemanaContext())
            {
                casedetails = dbContext.Casedetail.ToList();
            }
            return casedetails;
        }

        public List<Casedetail> Query(Casedetail casedetail)
        {
            List<Casedetail> casedetails = null;
            using (var dbContext = new casemanaContext())
            {
                casedetails = dbContext.Casedetail.Where(x => x.Cid == casedetail.Cid).ToList();
            }
            return casedetails;
        }

        public Casedetail ShowDetail(Casedetail casedetail)
        {
            using (var dbContext = new casemanaContext())
            {
                casedetail = dbContext.Casedetail.FirstOrDefault(x => x.Cid == casedetail.Cid);
            }
            return casedetail;
        }

        public int Create(Casedetail casedetail)
        {
            int count = 0;
            var newcasedetail = new Casedetail()
            {
                //Proid = casedetail.Proid,
                Uid = casedetail.Uid
            };
            using (var dbContext = new casemanaContext())
            {
                dbContext.Casedetail.Add(newcasedetail);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Del(int cid)
        {
            int count = 0;
            using (var dbContext = new casemanaContext())
            {
                var casedetail = new Casedetail() { Cid = cid };
                dbContext.Casedetail.Attach(casedetail);
                dbContext.Casedetail.Remove(casedetail);
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


        #endregion

    }
}
