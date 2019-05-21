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
        public Casedetail ShowDetail(int cid)
        {
            Casedetail casedetail = null;
            using (var dbContext = new CasemanaContext())
            {
                casedetail = dbContext.Casedetail.FirstOrDefault(x => x.Cid == cid);
            }
            return casedetail;
        }

        public int Create(Casedetail casedetail)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                dbContext.Casedetail.Add(casedetail);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Del(int cid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
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
        public int Update(Casedetail casedetail)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var x = dbContext.Casedetail.FirstOrDefault(u => u.Cid ==casedetail.Cid);
                x = casedetail;
                dbContext.Casedetail.Update(x);
                count = dbContext.SaveChanges();
            }
            if (count > 0) { return (int)casedetail.Cid; }
            else return count;
        }

        #endregion

    }
}
