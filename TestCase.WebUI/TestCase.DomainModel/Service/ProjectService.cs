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
                using (var dbContext = new casemanaContext())
                {
                    projects = dbContext.Project.ToList();
            }
             return projects;
        }
        public List<Project> Query(Project project)
        {
            List<Project> projects = null;
            using (var dbContext = new casemanaContext())
            {
                projects = dbContext.Project.Where(x => x.Proname == project.Proname).ToList();
            }
            return projects;
        }

        public Project ShowDetail(Project project) {
            using (var dbContext=new casemanaContext()) {
                project = dbContext.Project.FirstOrDefault(x => x.Proid == project.Proid);
            }
            return project;
        }

        public int Create(Project project) {
            int count = 0;
            var newproject = new Project() {
                //Proid = project.Proid,
                Proname = project.Proname,
            };
            using (var dbContext=new casemanaContext()) {
               dbContext.Project.Add(newproject);
                count = dbContext.SaveChanges();
            }
            return count; 
        }

        public int Del(int proid)
        {
            int count = 0;
            using (var dbContext = new casemanaContext())
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

    }
}
