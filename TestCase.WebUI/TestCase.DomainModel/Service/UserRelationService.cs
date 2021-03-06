﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class UserrelationService
    {
        public List<Userrelation> GetAll()
        {
            List<Userrelation> relations = null;
            using (var dbContext = new CasemanaContext())
            {
                relations = dbContext.Userrelation.ToList();
            }
            return relations;
        }
        public List<Userrelation> Query(Userrelation relation)
        {
            List<Userrelation> relations = null;
            using (var dbContext = new CasemanaContext())
            {
                relations = dbContext.Userrelation.Where(x => x.Name.Contains( relation.Name)).ToList();
            }
            return relations;
        }
   
        public List<Userrelation> QueryByProid(int proid)
        {
            List<Userrelation> relations = null;
            using (var dbContext = new CasemanaContext())
            {
                relations = dbContext.Userrelation.Where(x => x.Proid == proid).ToList();
            }
            return relations;
        }
        public Userrelation ShowDetail(int? uid)
        {
            Userrelation relation = new Userrelation();
            using (var dbContext = new CasemanaContext())
            {
                relation = dbContext.Userrelation.FirstOrDefault(x => x.Uid ==uid);
            }
            return relation;
        }

        public int Create(Userrelation relation)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                dbContext.Userrelation.Add(relation);
                count = dbContext.SaveChanges();
            }
            return count;
        }

        public int Del(int uid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var relation = new Userrelation() { Uid = uid };
                relation=dbContext.Userrelation.FirstOrDefault(x => x.Uid == uid);
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
        public int Update(Userrelation relation)
        {
            using (var dbContext = new CasemanaContext())
            {
                var x = dbContext.Userrelation.FirstOrDefault(u => u.Uid == relation.Uid);
                foreach (PropertyInfo info in typeof(Userrelation).GetProperties())
                {
                    PropertyInfo pro = typeof(Userrelation).GetProperty(info.Name);
                    if (pro != null)
                        info.SetValue(x, pro.GetValue(relation));
                }
                dbContext.Userrelation.Update(x);
            }
            return (int)relation.Uid;
        }
    }
    }
