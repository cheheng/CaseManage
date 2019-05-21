using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCase.Infrastructure.Data;

namespace TestCase.DomainModel.Service
{
    public class ProjectService
    {
        public List<Project> GetAll() {
            List<Project> projects = null;
                using (var dbContext = new CasemanaContext())
                {
                    projects = dbContext.Project.ToList();
            }
             return projects;
        }
        public List<Project> Query(Project project)
        {
            List<Project> projects = null;
            using (var dbContext = new CasemanaContext())
            {
                projects = dbContext.Project.Where(x => x.Proname == project.Proname).ToList();
            }
            return projects;
        }

        public Project ShowDetail(int proid) {
            Project project = new Project();
            using (var dbContext=new CasemanaContext()) {
                project = dbContext.Project.FirstOrDefault(x => x.Proid == proid);
            }
            return project;
        }

        public int Create(Project project) {
            int count = 0;
            using (var dbContext=new CasemanaContext()) {
               dbContext.Project.Add(project);
                count = dbContext.SaveChanges();
            }
            return count; 
        }

        public int Del(int proid)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var project = new Project() { Proid = proid };
                dbContext.Project.Attach(project);
                dbContext.Project.Remove(project);
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
        public int Update(Project project)
        {
            int count = 0;
            using (var dbContext = new CasemanaContext())
            {
                var x = dbContext.Project.FirstOrDefault(u => u.Proid == project.Proid);
                x = project;
                dbContext.Project.Update(x);
                count = dbContext.SaveChanges();
            }
            if (count > 0) { return project.Proid; }
            else return count;
        }
    }
}
