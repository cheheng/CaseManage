using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class UserService
    {
        public List<Userdetail> GetAll()
        {
            List<Userdetail> users = null;
            using (var dbContext = new CasemanaContext())
            {
                users = dbContext.Userdetail.ToList();
            }
            return users;
        }
        public List<Userdetail> Query(Userdetail user)
        {
            List<Userdetail> users = null;
            using (var dbContext = new CasemanaContext())
            {
                users = dbContext.Userdetail.Where(x => x.Uid == user.Uid).ToList();
            }
            return users;
        }

        public Userdetail ShowDetail(int? uid)
        {
            Userdetail user = null;
            using (var dbContext = new CasemanaContext())
            {
                user = dbContext.Userdetail.FirstOrDefault(x => x.Uid == uid);
            }
            return user;
        }

       

        public int Del(int uid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var user = new Userdetail() { Uid = uid };
                dbContext.Userdetail.Attach(user);
                dbContext.Userdetail.Remove(user);
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
